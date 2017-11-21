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
        public List<Branch> GetBranch(Company c)
        {
            DeadlineManagementContext context = new DeadlineManagementContext();
            using (context)

                return (from sc in context.branches
                                    .Include(x => x.company)
                        where sc.Id == c.Id
                        select sc).ToList();

        }
        public List<Department> GetDepartment(Branch c)
        {
            DeadlineManagementContext context = new DeadlineManagementContext();
            using (context)

                return (from sc in context.departments
                                    .Include(x => x.branches)
                        where sc.Id == c.Id
                        select sc).ToList();

        }

        public int GetFileDetail(int branch, int department)
        {
            DeadlineManagementContext context = new DeadlineManagementContext();
            using (context)
            {

               return (Convert.ToInt32((from sc in context.filetouploadeddetails
                              .Include(x => x.department.branches)
                                         where sc.department.Id == department && sc.department.branches.Id == branch
                                         select sc.Id).FirstOrDefault()));
                
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
        }
    }
}