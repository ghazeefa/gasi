using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeadlineManagmentSystem.Models
{
    public class GridModel
    {
        public int  Id {get;set;}
        public DateTime Dateofentery { get; set; }
         public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName  { get; set; }       
        public string FileCategoryName { get; set; }
        public string FileTypeName { get; set; }
        public string Path { get; set; }
       

    }

}