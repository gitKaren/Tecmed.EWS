using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Autofac;

namespace Spectrum.WinService
{
    class Program
    {
        static int Main(string[] args)
        {
            // Ioc Helper method for Autofac
            var container = IocConfig.RegisterDependencies();

            return (int)HostFactory.Run(cfg =>
            {
                cfg.Service(s => container.Resolve<SpectrumBackstage>());

                cfg.RunAsLocalSystem();
            });
        }
    }
}
