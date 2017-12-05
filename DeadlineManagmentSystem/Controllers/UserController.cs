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
        UserHelper h = new UserHelper();
        public ActionResult Index()
        {
            h.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            string username= h.GetUserexists(data["name"], data["Password"]);
            if (username!= null)
            {
                Session.Add(WebUtil.CURRENT_USER, username);
                return RedirectToAction("index", "Display");

            }
            return View();
        }
    }
}