using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadlineManagmentSystem.Models
{
    public class DDLModel
    {
        public string Name { get; set; }

        public string Caption { get; set; }

        public IEnumerable<SelectListItem> Values { get; set; }
    }
}