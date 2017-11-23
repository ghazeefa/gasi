using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeadlineManagementDB.Helper;
using System.Web.Mvc;
using DeadlineManagmentSystem.Models;
using DeadlineManagementDB.Supporting;
using DeadlineManagementDB.FileUpload;
using DeadlineManagementDB.Users;
using System.IO;

namespace DeadlineManagmentSystem.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile

         CommonHelper uh = new CommonHelper();
        CategoriesHelper ch = new CategoriesHelper();
        UploadFileHelper ufh = new UploadFileHelper();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Filetype= CommonHelper.ToSelectItemList(ch.GetFileType());
            //ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            //ViewBag.Department = CommonHelper.ToSelectItemList(ch.GetDepartment());
            return View();
        }
        [HttpPost]
        public ActionResult Index(UploadFileModel productmodel, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = fileUpload;
                ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
                ViewBag.Filetype = CommonHelper.ToSelectItemList(ch.GetFileType());
                FileUploaded fu = new FileUploaded();
                fu.Dateofentery = DateTime.Today;
                fu.filuploaded = new FileToUploadedDetail { Id = new CommonHelper().GetFileDetail(Convert.ToInt32(productmodel.Branch), Convert.ToInt32(productmodel.Department)) }; ;

                if (!string.IsNullOrEmpty(file.FileName))
                  { try
                    {
                        string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(fileUpload.FileName));
                        if (System.IO.File.Exists(path))
                        {
                            ViewBag.Message = "The File Already Exists in System";
                        }
                        else
                        {
                            file.SaveAs(path);
                            fu.Path = path;
                        }

                    }
                    catch (Exception exception)
                    {
                        ViewBag.Message = "ERROR:" + exception.Message.ToString();
                    }
                }
                //else
                //{
                //    ViewBag.Message = "Specify the file";
                //}

                //if (!string.IsNullOrEmpty(file.FileName))
                //{
                //    //string url = "~/Images/" + file.FileName.Substring(file.FileName.LastIndexOf("."));
                //    //string path = Server.MapPath(url);
                   
                //}
                fu.user = new User { Id = 1 };
                ufh.Add(fu);


            }

            return View();
        }
            [HttpGet]
        public ActionResult Branch(int id)
        {
            DDLModel m = new DDLModel();
            m.Name = "Branch";
            m.Caption = "- Select Branch -";
            m.Values = CommonHelper.ToSelectItemList(new BranchHelper().GetBranchesByCompanyId(id)); 
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);

        }
        [HttpGet]
        public ActionResult Department(int id)
        {
            DDLModel m = new DDLModel();
            m.Name = "Department";
            m.Caption = "- Select Department -";
            m.Values = CommonHelper.ToSelectItemList(new DepartmentHelper().GetDepartmentsByBranchId(id));
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);

        }
        
    }
}