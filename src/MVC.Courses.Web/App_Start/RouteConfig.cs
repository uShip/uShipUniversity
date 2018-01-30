using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC.Courses.Web.HttpHandler;

namespace MVC.Courses.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
//            routes.Add(new Route("home/status", new uShipRouteHandler()));
            //            routes.MapRoute(
            //                name: "Default",
            //                url: "{controller}/{action}/{id}",
            //                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //            );
            Route route = new Route("{controller}/{action}/{id}", new RouteValueDictionary
                {{"Controller", "Home"}, {"action", "Index"}, {"id", "1"}},
                new MvcRouteHandler());
            routes.Add(route);
        }

        public class uShipRouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new uShipHandler();
            }
        }
    }
}
