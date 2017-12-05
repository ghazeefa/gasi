using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DeadlineManagementDB.Supporting;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeadlineManagementDB.FileUpload
{
  public class FileToUploadedDetail
    {
 
        public int Id { get; set; }
        public Nullable<DateTime> DateToBeEntery { get; set; }

        public virtual FileType FileType { get; set; }
        //[Required]
        //public virtual Branch branch { get; set; }

        public virtual Department Department { get; set; }
        //[Required]
        //public virtual Branch branch{ get; set; }

    }
}
