using System.Web.Mvc;

using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetAgent");
        }

        public ActionResult GetAgent()
        {
            var responseData = $"Requesting Agent: { JsonConvert.SerializeObject(Request.ContentType, Formatting.None) }";
            return Content(responseData);
        }
    }
}