﻿using Autofac;
using Autofac.Integration.Mvc;
using Blog.Repository.Implementation;
using Blog.Repository.Interface;
using Blog.Service.Implementation;
using Blog.Service.Interface;
using Blogs.Controllers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blogs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureDependency();
        }

        private void ConfigureDependency()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HomeController>().InstancePerRequest();

            builder.RegisterType<TopicRepository>().As<ITopicRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<BlockRepository>().As<IBlockRepository>();

            builder.RegisterType<TopicService>().As<ITopicService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<BlockService>().As<IBlockService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}