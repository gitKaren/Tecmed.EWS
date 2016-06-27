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
    public class DepartmentCreatedConsumer : IConsumer<IDepartmentAddedToSite>
    {
        private ICommandProcessor _commandProcessor;

        public DepartmentCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IDepartmentAddedToSite> context)
        {
            SourceDepartmentCreateCommand cmd = new SourceDepartmentCreateCommand()
            {
                Id = context.Message.Id,
                siteID = context.Message.SiteId
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class DepartmentUpdatedConsumer : IConsumer<IDepartmentUpdatedInSite>
    {
        private ICommandProcessor _commandProcessor;

        public DepartmentUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IDepartmentUpdatedInSite> context)
        {
            SourceDepartmentUpdateCommand cmd = new SourceDepartmentUpdateCommand()
            {
                Id = context.Message.Id,
                siteID = context.Message.SiteId
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class DepartmentDeletedConsumer : IConsumer<IDepartmentRemovedFromSite>
    {
        private ICommandProcessor _commandProcessor;

        public DepartmentDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IDepartmentRemovedFromSite> context)
        {
            SourceDepartmentDeleteCommand cmd = new SourceDepartmentDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
