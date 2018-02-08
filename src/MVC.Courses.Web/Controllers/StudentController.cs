using System.Text;
using System.Web.Mvc;

using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult GetAgent()
        {
            return GiveMeJson("browser"); 
        }

        public JsonResult GiveMeJson(string requestObject)
        {
            object responseData;
            switch (requestObject)
            {
                case "headers":
                    responseData = JsonConvert.SerializeObject(Request.Headers, Formatting.None);
                    break;
                case "method":
                    responseData = JsonConvert.SerializeObject(Request.HttpMethod, Formatting.None);
                    break;
                case "browser":
                    responseData = JsonConvert.SerializeObject(Request.Browser, Formatting.None);
                    break;
                default:
                    responseData = JsonConvert.SerializeObject(Request);
                    break;
            }

            return new JsonResult
            {
                ContentEncoding = Encoding.ASCII,
                Data = responseData,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}