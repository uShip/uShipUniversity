using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        public RedirectResult Index()
        {
            return new RedirectResult("Student/GetAgent", false);
        }

        public ActionResult GetAgent()
        {
            var browser = Request.Browser.Browser;

            // Edge likes to pretend it is chrome, so we'll check to see if it really is chrome
            if (browser == "Chrome")
            {
                // Get the UserAgent string and check to see if it contains "Edge".  Chrome should not.
                var userAgent = Request.UserAgent;
                if (userAgent != null && userAgent.IndexOf("Edge", StringComparison.Ordinal) > -1)
                    browser = "Nice Try Edge";
            }

            return new JsonResult
            {
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = browser
            };
        }
    }
}