using MassTransit;
using Spectrum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data;
using EWS.Domain.Data.Commands.Sources;

namespace EWS.Application.Consumers
{
    public class SiteCreatedConsumer : IConsumer<ISiteCreated>
    {
        private ICommandProcessor _commandProcessor;

        public SiteCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISiteCreated> context)
        {
            SourceSiteCreateCommand cmd = new SourceSiteCreateCommand()
            {
                Id = context.Message.Id,
                SiteName = context.Message.SiteName,
                CustomerId = context.Message.CustomerId,
                MarketSegmentId = context.Message.MarketSegmentId,
                RegistrationNumber = context.Message.RegistrationNumber,
                SiteRef = context.Message.SiteRef,
                SupportBranchId = context.Message.SupportBranchId,
                VATNumber = context.Message.VATNumber
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class SiteUpdatedConsumer : IConsumer<ISiteUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public SiteUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISiteUpdated> context)
        {
            SourceSiteUpdateCommand cmd = new SourceSiteUpdateCommand()
            {
                Id = context.Message.Id,
                SiteName = context.Message.SiteName,
                CustomerId = context.Message.CustomerId,
                MarketSegmentId = context.Message.MarketSegmentId,
                RegistrationNumber = context.Message.RegistrationNumber,
                SiteRef = context.Message.SiteRef,
                SupportBranchId = context.Message.SupportBranchId,
                VATNumber = context.Message.VATNumber
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class SiteDeletedConsumer : IConsumer<ISiteDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public SiteDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISiteDeleted> context)
        {
            SourceSiteDeleteCommand cmd = new SourceSiteDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
