using Autofac;
using Autofac.Integration.Mvc;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Helpers;
using System.Globalization;
using System.Threading;

using EWS.Web.Models;

namespace EWS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalFilters.Filters.Add(new EWS.Web.Filters.AuthTokenActionFilter());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = System.IdentityModel.Claims.ClaimTypes.Name;

   

            ContainerBuilder builder = ContainerRegister();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var busControl = container.Resolve<IBusControl>();
            BusHandle handle = busControl.Start();
        }

        private ContainerBuilder ContainerRegister()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<EWS.Infrastructure.Entities>().As<EWS.Domain.Data.IEntityWriter>();
            builder.RegisterType<EWS.Infrastructure.Entities>().As<EWS.Domain.Data.IEntityReader>();
            builder.RegisterType<EWS.Web.Logic.Infrastructure.QueryProcessor>().As<EWS.Domain.Data.IQueryProcessor>();
            builder.RegisterType<EWS.Web.Logic.Infrastructure.CommandProcessor>().As<EWS.Domain.Data.ICommandProcessor>();
            builder.RegisterType<EWS.Web.Logic.Infrastructure.CurrentUserFactory>().As<EWS.Domain.DomainServices.ICurrentUserFactory>();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(EWS.Domain.Data.IQueryHandler<,>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(EWS.Domain.Data.ICommandHandler<>)).AsImplementedInterfaces();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //MASS TRANSIT
            System.Web.Compilation.BuildManager.GetReferencedAssemblies();
            builder.RegisterConsumers(AppDomain.CurrentDomain.GetAssemblies());


            builder.Register(context =>
            Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("EWS_Queue", ec =>
                {
                    ec.LoadFrom(context);
                });
            }))
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();

            //
            return builder;
        }



        // DateFormat Settings:
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {    
          CultureInfo newCulture = (CultureInfo) System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
          newCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
          newCulture.DateTimeFormat.DateSeparator = "/";
          Thread.CurrentThread.CurrentCulture = newCulture;
        }
    }
}
