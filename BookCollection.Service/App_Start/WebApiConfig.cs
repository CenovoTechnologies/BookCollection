﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookCollection.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RegisterUser",
                routeTemplate: "api/{controller}/Register"
            );

            config.Routes.MapHttpRoute(
                name: "LoginUser",
                routeTemplate: "api/{controller}/Login"
            );
        }
    }
}