using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult GetAgent()
        {
            return new JsonResult
            {
                ContentEncoding = Encoding.ASCII,
                Data = JsonConvert.SerializeObject(Request.Browser, Formatting.None),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}