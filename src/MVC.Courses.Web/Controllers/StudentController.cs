using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public JsonResult GetAgent() {
            return new JsonResult
            {
                ContentEncoding = Encoding.ASCII,
                Data = JsonConvert.SerializeObject(Request.Browser.Browser, Formatting.None),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}