//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeadlineManagementDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vw_PendingFiles
    {
        public int PendingFilesId { get; set; }
        public string FileName { get; set; }
        public int FileCategory_Id { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public int FileType_Id { get; set; }
        public Nullable<System.DateTime> datetoupload { get; set; }
        public int Branch_Id { get; set; }
        public string CompanyName { get; set; }
        public int DepartmentId { get; set; }
    }
}
