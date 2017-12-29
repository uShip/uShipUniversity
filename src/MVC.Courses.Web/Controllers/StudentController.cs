using System.Text;
using System.Web.Mvc;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public JsonResult GetAgent()
        {
            var agent = Request.Browser.Browser;            
            var rc = new JsonResult
            {
                Data = new { agent },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentEncoding = Encoding.UTF8,
                ContentType = "application/json"
            };
            return rc;
        }
    }
}