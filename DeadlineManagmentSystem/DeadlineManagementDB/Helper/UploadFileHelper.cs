using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeadlineManagementDB.FileUpload;
using System.Data.Entity.Validation;

namespace DeadlineManagementDB.Helper
{
    public class UploadFileHelper
    {
        public bool AddNewFile(FileUploaded f)
        {

            DeadlineManagementContext context = new DeadlineManagementContext();
            using (context)
            {
               
                   
                    using (context)
                    {
                        context.fileuploades.Add(f);
                        context.SaveChanges();
                        return true;
                    }

                
               
            }
        }
    }
}





























































































































































































































