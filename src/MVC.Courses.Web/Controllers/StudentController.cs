using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult GetAgent()
        {
            return Json(Request.Browser.Browser, JsonRequestBehavior.AllowGet);
        }

    }
}