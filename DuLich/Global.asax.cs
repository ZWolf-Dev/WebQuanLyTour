using DuLich.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DuLich
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //cấu hình cho web api
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //cấu hình cho web thường
            RouteConfig.RegisterRoutes(RouteTable.Routes);
      
        }
        //protected void Session_Start()
        //{
        //    Session["User"] = "";
        //}
    }
}
