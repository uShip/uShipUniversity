using System.Text;
using System.Web.Mvc;

using Newtonsoft.Json;

namespace MVC.Courses.Web.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return new RedirectResult("Home/Status", false);
        }

        public HttpStatusCodeResult Status()
        {
            return new HttpStatusCodeResult(200, "All uShip A-OK");
        }

        public ActionResult About()
        {
            //Jim's white space push
            return new EmptyResult();
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