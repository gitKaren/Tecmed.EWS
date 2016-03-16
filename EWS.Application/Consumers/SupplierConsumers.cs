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
    public class SupplierCreatedConsumer : IConsumer<ISupplierCreated>
    {
        private ICommandProcessor _commandProcessor;

        public SupplierCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISupplierCreated> context)
        {
            SourceSupplierCreateCommand cmd = new SourceSupplierCreateCommand()
            {
                Id = context.Message.Id,
                SupplierName = context.Message.SupplierName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class SupplierUpdatedConsumer : IConsumer<ISupplierUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public SupplierUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISupplierUpdated> context)
        {
            SourceSupplierUpdateCommand cmd = new SourceSupplierUpdateCommand()
            {
                Id = context.Message.Id,
                SupplierName = context.Message.SupplierName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class SupplierDeletedConsumer : IConsumer<ISupplierDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public SupplierDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISupplierDeleted> context)
        {
            SourceSupplierDeleteCommand cmd = new SourceSupplierDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
