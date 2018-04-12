using System.Web.Mvc;
using System.Web.Routing;

namespace TinyUrl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{tinyUrl}",
                new { controller = "Home", action = "Index", tinyUrl = "" }
            );
             
        }
    }
}
