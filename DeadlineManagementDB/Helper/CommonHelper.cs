using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DeadlineManagementDB.Supporting;
using DeadlineManagementDB.FileUpload;
using System.Data.Entity;
namespace DeadlineManagementDB.Helper
{
    public class CommonHelper
    {

        public static List<SelectListItem> ToSelectItemList(dynamic values)
        {
            List<SelectListItem> tempList = null;
            if (values != null)
            {
                tempList = new List<SelectListItem>();
                foreach (var v in values)
                {
                    tempList.Add(new SelectListItem { Text = v.Name, Value = Convert.ToString(v.Id) });
                }
                tempList.TrimExcess();
            }
            return tempList;
        }

        //public string GetUserexists(string name, string password) {
        //    string username;
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context) {
        //        var userlist = (from u in context.tblUsers
        //                        where u.FirstName == name && u.Password == password
        //                        select u
        //                         ).ToList().FirstOrDefault();
        //        username = userlist.SecondName;

        //    }
        //    return username;



        //}


        //public List<Vw_UploadedFileEdit> FindUploadedfile(int f) {

        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context) {
        //        return (from a in context.Vw_UploadedFileEdit
        //                where a.FileUploadedId == f
        //                select a).ToList();

        //    }




        //}
        //public List<tblDepartment> GetDepartment(int d) {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context)

        //        return (from sc in context.tblDepartments

        //                where sc.Branch_Id == d
        //                select sc).ToList();

        //}
        //public List<tbl_FileType> GetFileType(int d) {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context)

        //        return (from sc in context.tbl_FileType

        //                where sc.FileCategory_Id == d
        //                select sc).ToList();

        //}
        //public List<tblBranch> GetBranch(int c) {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context)

        //        return (from sc in context.tblBranches

        //                where sc.Company_Id == c
        //                select sc).ToList();

        //}

        //public int GetFileDetail(int file, int department) {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context) {

        //        return (Convert.ToInt32((from sc in context.tblToUploads
        //                                 where sc.department_Id == department && sc.filetype_Id == file
        //                                 select sc.Id).FirstOrDefault()));

        //    }
        //}
        //public IEnumerable<Vw_FileUploaded> GetUploadedFiles() {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context) {
        //        return context.Vw_FileUploaded.ToList().AsEnumerable();

        //    }
        //}

        //public List<Vw_PendingFiles> GetPendingFiles(int filecategory) {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context) {

        //        return (from sc in context.Vw_PendingFiles
        //                where sc.FileCategory_Id == filecategory
        //                select sc).ToList();

        //    }
        //}
        //public int GetBranchByDepartment(int departid) {
        //    ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
        //    using (context) {

        //        return (from sc in context.tblDepartments
        //                where sc.Id == departid
        //                select sc.Branch_Id).FirstOrDefault();

        //    }
        //}
        //public List<Branch> GetBranch(Company c)
        //{
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)

        //        return (from sc in context.branches
        //                            .Include(x => )
        //                where sc.Id == c.Id
        //                select sc).ToList();

        //}
        //public List<Department> GetDepartment(Branch c)
        //{
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)

        //        return (from sc in context.departments
        //                            .Include(x => x.branches)
        //                where sc.Id == c.Id
        //                select sc).ToList();

        //}

        //public int GetFileDetail(int branch, int department) {
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context) {

        //        return (Convert.ToInt32((from sc in context.filetouploadeddetails
        //                       .Include(x => x.department.Branch)
        //                                 where sc.department.Id == department && sc.department.Branch.Id == branch
        //                                 select sc.Id).FirstOrDefault()));

        //    }
        //public List<Branch> GetSubCategories(Branch c) {
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)

        //        return (from sc in context.branches
        //                            .Include(x => x.company)
        //                where sc.Id == c.Id
        //                select sc).ToList();

        //}
        //public List<Branch> GetSubCategories(Branch c) {
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)

        //        return (from sc in context.branches
        //                            .Include(x => x.company)
        //                where sc.Id == c.Id
        //                select sc).ToList();
        //}
        //}
    }
}