using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab01_ASPNET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ArrayStats",
                url: "{controller}/{action}/{Arr}",
                defaults: new { controller = "Calculation", action = "Index", Arr = UrlParameter.Optional }
            );

            routes.MapRoute(
                  name: "All",
                  url: "{controller}/{action}/{Number1}/{Number2}/{Do}",
                  defaults: new
                  {
                      controller = "Calculation",
                      action = "Index",
                      Number1 = UrlParameter.Optional,
                      Number2 = UrlParameter.Optional,
                      Do = UrlParameter.Optional,
                  }
              );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{Message}/{MoreMessage}",
                defaults: new { controller = "Home", action = "Index", Message = UrlParameter.Optional, MoreMessage = UrlParameter.Optional }
            );

          
        }
    }
}
