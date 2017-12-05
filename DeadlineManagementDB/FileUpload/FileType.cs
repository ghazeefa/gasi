using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeadlineManagementDB.FileUpload
{
   public class FileType
    {

        public int Id { get; set; }//1

        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Name { get; set; }//Leaves

        public int ReviseagainMonths { get; set; }//1


    }
}
