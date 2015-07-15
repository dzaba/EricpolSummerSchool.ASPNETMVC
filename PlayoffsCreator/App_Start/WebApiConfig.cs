using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
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

<<<<<<< HEAD
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
=======
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
>>>>>>> 1286043710990f3d6bdde96c57a7db5f957be602
            //TODO: cleanup
        }
    }
}
