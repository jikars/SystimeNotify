using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity.WebApi;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
           
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.RegisterComponents());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
