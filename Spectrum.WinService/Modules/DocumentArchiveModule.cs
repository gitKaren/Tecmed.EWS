using Autofac;
using Spectrum.DocumentArchive;
using Spectrum.DocumentArchive.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.WinService.Modules
{
    public class DocumentArchiveModule : Module
    {
        private readonly System.Reflection.Assembly[] _assembliesToScan;

        public DocumentArchiveModule(params System.Reflection.Assembly[] assembliesToScan)
        {
            _assembliesToScan = assembliesToScan;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SpectrumWinServiceDocumentRepository>().As<Spectrum.DocumentArchive.Repository.IDocumentRepository>();
            builder.RegisterType<DefaultExtensionValidator>().As<IExtensionValidator>();
            builder.RegisterType<DefaultSizeValidator>().As<ISizeValidator>();
            builder.RegisterType<SpectrumWinServiceFileStorer>().As<IFileStorer>();
        }
    }
}
