using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeadlineManagementDB.Supporting
{
    public class Company
    {
        public Company() {
            Branches = new List<Branch>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Name { get; set; }

        public ICollection<Branch> Branches { get; set; }
    }
}
