﻿using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Barchart.MarketData.WebApi.Controllers;
using Barchart.MarketData.WebApi.Services;

namespace Barchart.MarketData.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<IValuesController>().As<ValuesService>();
            builder.RegisterType<ValuesService>().As<IValuesController>();

            //builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
