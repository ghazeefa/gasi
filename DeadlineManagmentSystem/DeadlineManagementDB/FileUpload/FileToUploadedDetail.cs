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
        [Required]
        [Key]
        public int Id { get; set; }
        public Nullable<DateTime> Datetobeentery { get; set; }
        [Required]
        public virtual FileType filetype { get; set; }
        //[Required]
        //public virtual Branch branch { get; set; }
        [Required]
        public virtual Department department { get; set; }
        //[Required]
        //public virtual Branch branch{ get; set; }

    }
}
