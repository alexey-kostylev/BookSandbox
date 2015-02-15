using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace BookSandbox
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Details",
            //    routeTemplate: "api/My/{id}",
            //    defaults: new { id = RouteParameter.Optional, action = "GetDetails" },
            //    constraints: new { id = @"\d*" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Echo",
            //    routeTemplate: "api/My/{str}",
            //    defaults: new { action = "GetEcho" }
            // ); 

            //config.Routes.MapHttpRoute(
            //    name: "DetailsEx",
            //    routeTemplate: "api/My/{category}/{year}",
            //    defaults: new { action = "GetDetailsEx", controller = "My" },
            //    constraints: new { year = @"\d*" }
            //);

            //config.Routes.MapHttpRoute(
            //   name: "DefaultMyApi1",
            //   routeTemplate: "api/My/{id}",
            //   defaults: new { id = RouteParameter.Optional, controller = "My" },
            //   constraints: new { id = @"\d*" }
            //); 

            //config.Routes.MapHttpRoute(
            //   name: "DefaultMyApi",
            //   routeTemplate: "api/My/{str}",
            //   defaults: new { str = RouteParameter.Optional, controller="My" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "My",
            //    routeTemplate: "api/My/{echo}",
            //    defaults: new { echo = RouteParameter.Optional, controller="My" }                
            //);

            config.Routes.MapHttpRoute(
                name: "My",
                routeTemplate: "api/My/{id}",
                defaults: new { echo = RouteParameter.Optional, controller="My" },
                constraints: new { id=@"\d+" }
            );

            config.Routes.MapHttpRoute(
                name: "MyEcho",
                routeTemplate: "api/{controller}/{echo}",
                defaults: new { echo = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
