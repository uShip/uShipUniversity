using System;
using System.Diagnostics;
using System.Web;

namespace MVC.Courses.Web.HttpModules
{
    public class Logger : IHttpModule
    {
        private HttpApplication _appContext;
        public void Init(HttpApplication context)
        {
            _appContext = context;
            Debug.WriteLine("Logger.Init()");
            context.MapRequestHandler += MapHandler;
        }

        private void MapHandler(object sender, EventArgs e)
        {
            if (_appContext.Request.RequestContext.HttpContext.Request.RawUrl.Contains("Home/Drunk"))
            {
                Debug.WriteLine("Browser, you're drunk ... go get Jason");
                _appContext.Response.Redirect("/Home/givemejson?requestObject=headers");
            }
        }

        public void Dispose()
        {
            Debug.WriteLine("Logger.Dispose()");
        }
    }
}