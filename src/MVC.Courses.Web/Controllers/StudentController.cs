//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        public JsonResult Agent()
        {
            object responseData = JsonConvert.SerializeObject(Request.Browser.Browser, Formatting.None);
            return new JsonResult
            {
                ContentEncoding = Encoding.ASCII,
                Data = responseData,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
