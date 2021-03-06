﻿using System;
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
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Path { get; set; }
        [Required]
        public DateTime Dateofentery { get; set; }
        [Required]
        public virtual FileToUploadedDetail filuploaded { get; set; }

        public Nullable<DateTime> Dateentered { get; set; }

        public virtual User user { get; set; }
    }
}
