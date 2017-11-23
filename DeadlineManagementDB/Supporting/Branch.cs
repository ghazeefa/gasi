using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeadlineManagementDB.Supporting
{
   public class Branch
    {
        public Branch() {
            Departments = new List<Department>();
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Name { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
