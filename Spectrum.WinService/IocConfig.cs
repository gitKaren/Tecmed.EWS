using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Spectrum.WinService.Modules;

namespace Spectrum.WinService
{
    public class IocConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SpectrumBackstage>();

            builder.RegisterModule(new BusModule(Assembly.GetExecutingAssembly()));
            builder.RegisterModule(new DocumentArchiveModule(Assembly.GetExecutingAssembly()));

            return builder.Build();
        }
    }
}
