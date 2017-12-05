using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeadlineManagementDB.Helper;
using System.Web.Mvc;
using DeadlineManagementDB;
using DeadlineManagmentSystem.Models;
using DeadlineManagementDB.Supporting;
using DeadlineManagementDB.FileUpload;
using DeadlineManagementDB.Users;
using System.Data.Entity;
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
            ViewBag.FileCategory = CommonHelper.ToSelectItemList(ch.GetFileCategory());
            //ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            //ViewBag.Department = CommonHelper.ToSelectItemList(ch.GetDepartment());
            return View();
        }
        [HttpPost]
        public ActionResult Index(UploadFileModel filemodel, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = fileUpload;
                ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
                ViewBag.FileCategory = CommonHelper.ToSelectItemList(ch.GetFileCategory());
                tblFileUploaded fu = new tblFileUploaded();
                fu.Dateofentery = DateTime.Today;
                //fu.Filuploaded_Id = new FileToUploadedDetail { Id = uh.GetFileDetail(Convert.ToInt32(productmodel.Branch), Convert.ToInt32(productmodel.Department)) }; ;
                fu.Filuploaded_Id = uh.GetFileDetail(Convert.ToInt32(filemodel.FileType), Convert.ToInt32(filemodel.Department));
;
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

                fu.User_Id =  1 ;
                ufh.AddNewFile(fu);


            }

            return View();
        }

        [HttpGet]
        public ActionResult IndexGrid(String param)
        {
            // Only grid string query values will be visible here.
            return PartialView("_IndexGrid", uh.GetUploadedFiles());
        }
        [HttpGet]
        public ActionResult Branch(int id)
        {
            DDLModel m = new DDLModel();
            m.Name = "Branch";
            m.Caption = "- Select Branch -";
            m.Values = CommonHelper.ToSelectItemList(new CommonHelper().GetBranch(id));
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);

        }
        [HttpGet]
        public ActionResult Department(int id)
        {
            DDLModel m = new DDLModel();
            m.Name = "Department";
            m.Caption = "- Select Department -";
            m.Values = CommonHelper.ToSelectItemList(new CommonHelper().GetDepartment( id ));
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);

        }

        [HttpGet]
        public ActionResult FileType(int id)
        {
            DDLModel m = new DDLModel();
            m.Name = "FileType";
            m.Caption = "- Select File Type -";
            m.Values = CommonHelper.ToSelectItemList(new CommonHelper().GetFileType(id));
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);

        }
        
        [HttpGet]
        public ActionResult FileGrid()
        {
            //ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            //using (context)
            //{
            //    return View(context.Vw_FileUploaded.Set<GridModel>().OrderBy(model => model.Id));
            //}



            //GridModel m = new DDLModel();
            //m.Name = "FileType";
            //m.Caption = "- Select File Type -";
            //m.Values = CommonHelper.ToSelectItemList(new CommonHelper().GetFileType(id));

            //List<Vw_FileUploaded> model = uh.GetUploadedFile();
            List<GridModel> gm = new List<GridModel>();
            uh.GetUploadedFiles().ToList().ForEach(X =>
            {
                gm.Add(new GridModel
                {
                    BranchName = X.BranchName,
                    CompanyName = X.CompanyName,
                    Id = X.Id,
                    DepartmentName = X.DepartmentName,
                    FileCategoryName = X.FileCategoryName,
                    FileTypeName = X.FileTypeName
                });
            });
            return PartialView("~/Views/Shared/_FileGrid.cshtml", gm);
            //return PartialView("~/Views/Shared/_FileGrid.cshtml", model);

        }
    }
}