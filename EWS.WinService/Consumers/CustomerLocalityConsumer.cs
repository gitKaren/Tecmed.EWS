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
    public class CustomerLocalityCreatedConsumer : IConsumer<ICustomerLocalityCreated>
    {
        private ICommandProcessor _commandProcessor;

        public CustomerLocalityCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICustomerLocalityCreated> context)
        {
            SourceCustomerLocalityCreateCommand cmd = new SourceCustomerLocalityCreateCommand()
            {
                Id = context.Message.Id,
                SupplierId = context.Message.SupplierId,
                CustomerLocalityName = context.Message.CustomerLocalityName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CustomerLocalityUpdatedConsumer : IConsumer<ICustomerLocalityUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public CustomerLocalityUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICustomerLocalityUpdated> context)
        {
            SourceCustomerLocalityUpdateCommand cmd = new SourceCustomerLocalityUpdateCommand()
            {
                Id = context.Message.Id,
                SupplierId = context.Message.SupplierId,
                CustomerLocalityName = context.Message.CustomerLocalityName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CustomerLocalityDeletedConsumer : IConsumer<ICustomerLocalityDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public CustomerLocalityDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICustomerLocalityDeleted> context)
        {
            SourceCustomerLocalityDeleteCommand cmd = new SourceCustomerLocalityDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
