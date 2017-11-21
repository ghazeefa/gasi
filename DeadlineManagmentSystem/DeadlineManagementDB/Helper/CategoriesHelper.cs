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

        public List<Branch> GetBranch()
        {
            DeadlineManagementContext context = new DeadlineManagementContext();
            using (context)
            {
                return (from a in context.branches select a).ToList();
            }


        }
        public List<FileType> GetFileType()
        {
            DeadlineManagementContext context = new DeadlineManagementContext();
            using (context)
            {
                return (from a in context.filetypes select a).ToList();
            }


        }
        //public List<Department> GetDepartment()
        //{
        //    DeadlineManagementContext context = new DeadlineManagementContext();
        //    using (context)
        //    {
        //        return (from a in context.departments select a).ToList();
        //    }


        //}



    }
}
