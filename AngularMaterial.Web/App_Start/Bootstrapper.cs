using AngularMaterial.Data;
using AngularMaterial.Data.Repositories;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularMaterial.Web.App_Start
{
    public class Bootstrapper
    {
        public static void RegisterAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            //var config = GlobalConfiguration.Configuration;

            // Register web api controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register EF context
            builder.RegisterType<AngularMaterialContext>().As<DbContext>().InstancePerRequest();

            // Register generic repository
            builder.RegisterGeneric(typeof(EntityBaseRepository<>))
                .As(typeof(IEntityBaseRepository<>)).InstancePerRequest();

            // Set the dependency resolver to be autofac
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
