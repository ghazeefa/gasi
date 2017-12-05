using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeadlineManagementDB.Helper;
using DeadlineManagmentSystem.Models;
using DeadlineManagementDB.Supporting;
using DeadlineManagementDB.FileUpload;
using DeadlineManagementDB.Users;
using System.IO;

namespace DeadlineManagmentSystem.Controllers
{
    public class FileTouploadController : Controller
    {
        // GET: FileToupload
        CommonHelper uh = new CommonHelper();
        CategoriesHelper ch = new CategoriesHelper();
        UploadFileHelper ufh = new UploadFileHelper();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Filetype = CommonHelper.ToSelectItemList(ch.GetFileCategory());
            //ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Department = CommonHelper.ToSelectItemList(ch.GetDepartment());
            return View();
        
        }

        [HttpPost]
        public ActionResult Index(FileTobeUploadModel f)
        {  ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Filetype = CommonHelper.ToSelectItemList(ch.GetFileCategory());
            //ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Department = CommonHelper.ToSelectItemList(ch.GetDepartment());
            FileToUploadedDetail ft = new FileToUploadedDetail();
            ft.department = new Department { Id = Convert.ToInt32(f.Department) } ;
            ft.filetype = new FileType { Id = f.FileTypeId };
             ft.Datetobeentery = Convert.ToDateTime(f.DateofDeadline);
            return View();

        }
        //[HttpGet]
        //public ActionResult Department(int id)
        //{
        //    DDLModel m = new DDLModel();
        //    m.Name = "Department";
        //    m.Caption = "- Select Department -";
        //    m.Values = CommonHelper.ToSelectItemList(new CommonHelper().GetDepartment(new Branch { Id = id }));
        //    return PartialView("~/Views/Shared/_DDLView.cshtml", m);

        //}
    }
}