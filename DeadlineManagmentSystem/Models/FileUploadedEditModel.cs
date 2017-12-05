using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeadlineManagmentSystem.Models
{
    public class FileUploadedEditModel
    {
        public int fileUploadedId { get; set; }
        public int FileTypeId { get; set; }
        public int FileCategoryId { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public string path { get; set; }
        public DateTime DateUpload {get; set;}
       

    }
}