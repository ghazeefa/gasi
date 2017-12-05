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

        public bool AddNewFile(tblFileUploaded f)
        {


            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {
               
                   
                    using (context)
                    {
                    context.tblFileUploadeds.Add(f);
                    context.SaveChanges();
                    return true;
                }

                
               
            }
        }

        public bool GetFilesUploaded(tblFileUploaded f)
        {


            ComfortComplianceDeadlineDBEntities1 context = new ComfortComplianceDeadlineDBEntities1();
            using (context)
            {


                using (context)
                {
                    context.tblFileUploadeds.Add(f);
                    context.SaveChanges();
                    return true;
                }



            }
        }

    }
}





























































































































































































































