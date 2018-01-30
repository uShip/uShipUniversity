using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC.Courses.Web;
using MVC.Courses.Web.HttpModules;

[assembly:PreApplicationStartMethod(typeof(MvcApplication), "Register")]

namespace MVC.Courses.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(Logger));
        }

        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            Debug.WriteLine("BYE!");
        }

        protected void Application_BeginRequest()
        {
            Debug.WriteLine("BeinRequest()");
        }

        protected void Application_ResolveRequestCache()
        {
            Debug.WriteLine("ResolveRequestCache()");
        }
        protected void Application_PostResolveRequestCache()
        {
            Debug.WriteLine("PostResolveRequestCache()");
        }

        protected void Application_MapRequestHandler()
        {
            Debug.WriteLine("MapRequestHandler()");
        }

        protected void Application_PostMapRequestHandler()
        {
            Debug.WriteLine("PostMapRequestHandler()");
        }

        protected void Application_AcquireRequiredState()
        {
            Debug.WriteLine("AcquireRequiredState()");
        }

        protected void Application_PreRequestHandlerExecute()
        {
            Debug.WriteLine("PreRequestHandlerExecute()");
        }

        protected void Application_PostRequestHandlerExecute()
        {
            Debug.WriteLine("PostRequestHandlerExecute()");
        }

        protected void Application_EndRequest()
        {
            Debug.WriteLine("EndRequest");
        }

    }
}