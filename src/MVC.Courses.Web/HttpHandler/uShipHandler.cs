using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Courses.Web.HttpHandler
{
    public class uShipHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<span>What would you like to SHIP today?</span>");
        }

        public bool IsReusable { get { return false; } }
    }
}