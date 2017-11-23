using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DeadlineManagementDB.Users;
namespace DeadlineManagementDB.FileUpload
{
    public class FileUploaded
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Path { get; set; }

        public DateTime Dateofentery { get; set; }

        public virtual FileToUploadedDetail filuploaded { get; set; }

        public Nullable<DateTime> Dateentered { get; set; }

        public virtual User user { get; set; }
    }
}
