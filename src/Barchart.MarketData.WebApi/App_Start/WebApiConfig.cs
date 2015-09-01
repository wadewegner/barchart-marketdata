using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Barchart.MarketData.WebApi.Controllers;
using Barchart.MarketData.WebApi.Services;

namespace Barchart.MarketData.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ValuesService>().As<IValuesController>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

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
