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
using DeadlineManagementDB.FileUpload;

namespace DeadlineManagmentSystem.Controllers
{
    public class DisplayController : Controller
    {
        private CategoriesHelper categoriesHelper = new CategoriesHelper();
        private BranchHelper branchHelper = new BranchHelper();
        private DepartmentHelper departmentHelper = new DepartmentHelper();
        private FileTypeHelper fileTypeHelper = new FileTypeHelper();
        private FileCategoryHelper fileCategoryHelper = new FileCategoryHelper();
        private FileUploadedHelper fileUploadedHelper = new FileUploadedHelper();
        private CommonHelper uh = new CommonHelper();

        public ActionResult Index()
        {
            ViewBag.Branch = CommonHelper.ToSelectItemList(branchHelper.GetAll());
            ViewBag.FileCategory = CommonHelper.ToSelectItemList(categoriesHelper.GetAll());

            List<GridModel> gm = new List<GridModel>();
            fileUploadedHelper.GetAll().ToList().ForEach(x => {
                gm.Add(new GridModel {
                    Id = x.Id,
                    BranchName = x.FileUploadedDetail.Department.Branch.Name,
                    CompanyName = x.FileUploadedDetail.Department.Branch.Company.Name,
                    DepartmentName = x.FileUploadedDetail.Department.Name,
                    FileCategoryName = x.FileUploadedDetail.FileType.FileCategory.Name,
                    FileTypeName = x.FileUploadedDetail.FileType.Name
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
            FileUploaded fu = fileUploadedHelper.GetById(id);

            var branchlist = CommonHelper.ToSelectItemList(branchHelper.GetAll());
            branchlist.Find(b => Convert.ToInt32(b.Value) == fu.FileUploadedDetail.Department.Branch.Id).Selected = true;
            ViewBag.Branch = branchlist;

            var departmentlist = CommonHelper.ToSelectItemList(departmentHelper.GetAll());
            departmentlist.Find(d => Convert.ToInt32(d.Value) == fu.FileUploadedDetail.Department.Id).Selected = true;
            ViewBag.Department = departmentlist;

            var filetypelst = CommonHelper.ToSelectItemList(fileTypeHelper.GetAll());
            filetypelst.Find(ft => Convert.ToInt32(ft.Value) == fu.FileUploadedDetail.FileType.Id).Selected = true;
            ViewBag.FileType = filetypelst;

            var filecatlst = CommonHelper.ToSelectItemList(fileCategoryHelper.GetAll());
            filecatlst.Find(fc => Convert.ToInt32(fc.Value) == fu.FileUploadedDetail.FileType.FileCategory.Id).Selected = true;
            ViewBag.FileCategory = filecatlst;

            FileUploadedEditModel em = new FileUploadedEditModel() {
                BranchId = fu.FileUploadedDetail.Department.Branch.Id,
                DepartmentId = fu.FileUploadedDetail.Department.Id,
                FileTypeId = fu.FileUploadedDetail.FileType.Id,
                FileCategoryId = fu.FileUploadedDetail.FileType.FileCategory.Id,
                path = fu.Path,
                DateUpload = fu.DateOfEntery,
                fileUploadedId = fu.Id
            };
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
            fileUploadedHelper.GetAll().ToList().ForEach(X =>
            {
                fileUploadedHelper.GetAll().ToList().ForEach(x => {
                    gm.Add(new GridModel {
                        Id = x.Id,
                        BranchName = x.FileUploadedDetail.Department.Branch.Name,
                        CompanyName = x.FileUploadedDetail.Department.Branch.Company.Name,
                        DepartmentName = x.FileUploadedDetail.Department.Name,
                        FileCategoryName = x.FileUploadedDetail.FileType.FileCategory.Name,
                        FileTypeName = x.FileUploadedDetail.FileType.Name
                    });
                });
            });
            return PartialView("~/Views/Shared/_FileGrid.cshtml", gm);


        }
    }
}