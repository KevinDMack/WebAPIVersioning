using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace APIMDemo.BackEndServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiMessage",
            //    routeTemplate: "api/{controller}/{message}",
            //    defaults: new { message = RouteParameter.Optional }
            //);

            //Controller Action
            //config.Routes.MapHttpRoute(
            //    name: "Messagev1",
            //    routeTemplate: "api/v1/message/{message}",
            //    defaults: new { controller = "message", message = RouteParameter.Optional }
            //    );

            //config.Routes.MapHttpRoute(
            //    name: "Messagev2",
            //    routeTemplate: "api/v2/message/{message}",
            //    defaults: new { controller = "messagev2", message = RouteParameter.Optional }
            //    );

            if (ConfigurationManager.AppSettings["VersioningSchema"] != VersioningSchema.UrlEmbedded)
            {
                config.Services.Replace(typeof(IHttpControllerSelector), new VersionControllerSelector((config)));
            }
        }
    }
}
