using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeadlineManagementDB.Supporting;
using System.Data.Entity;
using DeadlineManagementDB.FileUpload;

namespace DeadlineManagementDB.Helper
{
   public class CategoriesHelper
    {
        //public List<Branch> GetSubBranches(Company c)
        //{
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    u                                                                                                                                                                                                sing (context)

        //        return (from sc in context.branches
        //                            .Include(x => x.company)
        //                where sc.company.Id == c.Id
        //                select sc).ToList();

        //}

        public List<tblBranch> GetBranch()
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {
                return (from a in context.tblBranches select a).ToList();
            }

        }
        public List<tblFileCategory> GetFileCategory()
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {
                return (from a in context.tblFileCategories
                        select a).ToList();
            }


        }
        public List<tblDepartment> GetDepartment()
        {
            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {
                return (from a in context.tblDepartments select a).ToList();
            }


        }



    }
}
