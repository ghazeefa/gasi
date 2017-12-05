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
        //public List<Branch> GetBranch(Company c)
        //{
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)

        //        return (from sc in context.branches
        //                            .Include(x => x.company)
        //                where sc.Id == c.Id
        //                select sc).ToList();

        //}

        public int GetUserexists(string name, string password)
        {
            int id = 0;
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {
                var userlist = (from u in context.tblUsers
                                where u.FirstName == name && u.Password == password
                                select u
                                 ).ToList().FirstOrDefault();
                id = userlist.Id;

            }
            return id;



        }
        public List<tblDepartment> GetDepartment(int d)
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)

                return (from sc in context.tblDepartments
                                   
                        where sc.Branch_Id == d
                        select sc).ToList();

        }
        public List<tbl_FileType> GetFileType(int d)
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)

                return (from sc in context.tbl_FileType

                        where sc.FileCategory_Id == d
                        select sc).ToList();

        }
        public List<tblBranch> GetBranch(int c)
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)

                return (from sc in context.tblBranches

                        where sc.Company_Id == c
                        select sc).ToList();

        }

        public int GetFileDetail(int file, int department)
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {

                return (Convert.ToInt32((from sc in context.tblToUploads
                                         where sc.department_Id == department && sc.filetype_Id == file
                                         select sc.Id).FirstOrDefault()));

            }
        }
        public List<Vw_FileUploaded> GetUploadedFile()
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {
                return (from sc in context.Vw_FileUploaded
                        select sc).ToList();

            }
        }
        //public List<Branch> GetSubCategories(Branch c)
        //{
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)

        //        return (from sc in context.branches
        //                            .Include(x => x.company)
        //                where sc.Id == c.Id
        //                select sc).ToList();

        //}
        //  public List<Branch> GetSubCategories(Branch c)
        //{
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