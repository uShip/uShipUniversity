using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public JsonResult GetAgent()
        {
            var fact = $"You are using {Request.Browser.Browser}.. probably.";
            var opinion = Request.Browser.Browser == "InternetExplorer"
                ? "You really should get a better browser."
                : "That is just splendid.";

            var responseData = new 
            {
                result = $"{fact} {opinion}"
            };

            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
    }
}