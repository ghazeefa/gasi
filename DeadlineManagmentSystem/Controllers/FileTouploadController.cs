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
        private CategoriesHelper categoriesHelper = new CategoriesHelper();
        private BranchHelper branchHelper = new BranchHelper();
        private DepartmentHelper departmentHelper = new DepartmentHelper();
        CommonHelper uh = new CommonHelper();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Branch = CommonHelper.ToSelectItemList(branchHelper.GetAll());
            ViewBag.Filetype = CommonHelper.ToSelectItemList(categoriesHelper.GetAll());
            //ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Department = CommonHelper.ToSelectItemList(departmentHelper.GetAll());
            return View();
        
        }

        [HttpPost]
        public ActionResult Index(FileTobeUploadModel f)
        {  ViewBag.Branch = CommonHelper.ToSelectItemList(branchHelper.GetAll());
            ViewBag.Filetype = CommonHelper.ToSelectItemList(categoriesHelper.GetAll());
            //ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Department = CommonHelper.ToSelectItemList(departmentHelper.GetAll());
            FileToUploadedDetail ft = new FileToUploadedDetail();
            ft.Department = new Department { Id = Convert.ToInt32(f.Department) } ;
            ft.FileType = new FileType { Id = f.FileTypeId };
             ft.DateToBeEntery = Convert.ToDateTime(f.DateofDeadline);
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