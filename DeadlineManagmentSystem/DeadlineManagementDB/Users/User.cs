using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DeadlineManagementDB.Supporting;
namespace DeadlineManagementDB.Users
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string SecondName { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public virtual Department department { get; set; }

        //[Required]
        //public virtual Branch branch { get; set; }
    
        public Nullable<bool> IsActive { get; set; }
    }
}
