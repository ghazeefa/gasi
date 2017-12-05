using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeadlineManagementDB.Helper;
namespace DeadlineManagmentSystem.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        CommonHelper h = new CommonHelper();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            int userid = h.GetUserexists(data["name"], data["Password"]);
            if (userid != 0)
            {
                return RedirectToAction("index", "UploadFileModel");

            }
            return View();
        }
    }
}