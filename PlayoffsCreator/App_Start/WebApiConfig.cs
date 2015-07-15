using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PlayoffsCreator.Controllers;

namespace PlayoffsCreator
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

            config.Routes.MapHttpRoute(
                name: "PlayerApi",
                routeTemplate: "PlayerAPI/{id}",
                defaults: new { controller = "PlayerAPI", id = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
                name: "TeamApi",
                routeTemplate: "TeamApi/{id}",
                defaults: new { controller = "TeamApi", id = RouteParameter.Optional }
            );
            //TODO: cleanup
        }
    }
}
