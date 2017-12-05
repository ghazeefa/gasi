using DeadlineManagementDB.Helper;
using DeadlineManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeadlineManagementDB;
namespace DeadlineManagmentSystem.Controllers
{
    public class DisplayController : Controller
    {
        CategoriesHelper ch = new CategoriesHelper();
        CommonHelper uh = new CommonHelper();
        public ActionResult Index()
        {
            ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.FileCategory = CommonHelper.ToSelectItemList(ch.GetFileCategory());
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
            return View(gm);
        }
        // GET: Grocery/Edit/5
        [HttpGet]
        public ActionResult EditAction(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ViewBag.Branch = CommonHelper.ToSelectItemList(ch.GetBranch());
            ViewBag.Department = CommonHelper.ToSelectItemList(ch.GetDepartmentdata());
            ViewBag.FileType = CommonHelper.ToSelectItemList(ch.GetFileType());
            ViewBag.FileCategory = CommonHelper.ToSelectItemList(ch.GetFileCategory());
            List<FileUploadedEditModel> gm = new List<FileUploadedEditModel>();
            uh.FindUploadedfile(id).ToList().ForEach(X =>
            {
                gm.Add(new FileUploadedEditModel
                {
                    BranchId = X.BranchId,
                    DepartmentId = X.DepartmentId,
                    FileTypeId = X.FileTypeId,
                    FileCategoryId = X.FileCategoryId,
                    path = X.Path,
                    DateUpload = Convert.ToDateTime(X.Dateofentery)
                });
            });
            //if (grocery == null)
            //{
            //    return HttpNotFound();
            //}
            //return RedirectToAction("Edit", "Display");
            return View("~/Views/Display/Edit.cshtml");
        }


        //[HttpPost]
        //public ActionResult Edit(FileUploadedEditModel model)
        //{
        //    //if (id == null)
        //{
        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}

        //List<FileUploadedEditModel> gm = new List<FileUploadedEditModel>();
        //uh.FindUploadedfile(id).ToList().ForEach(X =>
        //{
        //    gm.Add(new FileUploadedEditModel
        //    {
        //        BranchId = X.BranchId,
        //        DepartmentId = X.DepartmentId,
        //        FileTypeId = X.FileTypeId,
        //        FileCategoryId = X.FileCategoryId,
        //        path = X.Path,
        //        DateUpload = Convert.ToDateTime(X.Dateofentery)
        //    });
        //});
        //if (grocery == null)
        //{
        //    return HttpNotFound();
        //}   


        //    List<GridModel> gm = new List<GridModel>();
        //    uh.GetUploadedFiles().ToList().ForEach(X =>
        //    {
        //        gm.Add(new GridModel
        //        {
        //            BranchName = X.BranchName,
        //            CompanyName = X.CompanyName,
        //            Id = X.Id,
        //            DepartmentName = X.DepartmentName,
        //            FileCategoryName = X.FileCategoryName,
        //            FileTypeName = X.FileTypeName
        //        });
        //    });
        //    return View("~/Views/Display/index.cshtml", gm);
        //}



        //[HttpPost]
        //public ActionResult Index()
        //{
        //    List<GridModel> gm = new List<GridModel>();
        //    uh.GetUploadedFiles().ToList().ForEach(X =>
        //    {
        //        gm.Add(new GridModel
        //        {
        //            BranchName = X.BranchName,
        //            CompanyName = X.CompanyName,
        //            Id = X.Id,
        //            DepartmentName = X.DepartmentName,
        //            FileCategoryName = X.FileCategoryName,
        //            FileTypeName = X.FileTypeName
        //        });
        //    });
        //    return View(gm);
        //}
        [HttpGet]
        public ActionResult FileGrid()
        {
  
            List<GridModel> gm = new List<GridModel>();
            uh.GetUploadedFiles().ToList().ForEach(X =>
            {
                gm.Add(new GridModel
                {
                    BranchName = X.BranchName,
                    CompanyName = X.CompanyName,
                    Id = X.Id,
                    DepartmentName = X.DepartmentName,
                    FileCategoryName=X.FileCategoryName,
                    FileTypeName=X.FileTypeName
                });
            });
            return PartialView("~/Views/Shared/_FileGrid.cshtml", gm);


        }
    }
}