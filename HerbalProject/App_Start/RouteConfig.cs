using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HerbalProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SimpleHerb",
                url: "herb/{name}",
                defaults: new { controller = "Herb", action = "Index", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "alphabet",
                url: "alphabet/{letter}",
                defaults: new { controller = "Search", action = "textList", letter = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SearchBySickness",
                url: "SearchBySickness/{r}",
                defaults: new { controller = "Search", action = "searchReseips", r = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SearchByNames",
                url: "SearchByNames/{s}",
                defaults: new { controller = "Search", action = "searchAll", s = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
            "404-PageNotFound",
            "{*url}",
            new { controller = "Home", action = "PageNotFound" }
            );

        }
    }
}