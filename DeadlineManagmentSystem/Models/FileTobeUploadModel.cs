﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DeadlineManagmentSystem.Models
{
    public class FileTobeUploadModel
    {

        public int FileTypeId { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string FileType { get; set; }
        public string Branch { get; set; }
        public DateTime DateofDeadline{ get; set; }

    }
}