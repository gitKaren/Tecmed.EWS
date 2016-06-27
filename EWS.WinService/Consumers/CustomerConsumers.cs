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
    public class CustomerCreatedConsumer : IConsumer<ICustomerCreated>
    {
        private ICommandProcessor _commandProcessor;

        public CustomerCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICustomerCreated> context)
        {
            SourceCustomerCreateCommand cmd = new SourceCustomerCreateCommand()
            {
                Id = context.Message.Id,
                customerLocalityID = context.Message.CustomerLocalityId,
                customerTypeID = context.Message.CustomerTypeId,
                IsGovernment = context.Message.IsGovernment,
                IsInternational = context.Message.IsInternational,
                CustomerNameFriendly = context.Message.CustomerName,
                CustomerName = context.Message.CustomerName,
                managementCompanyID = context.Message.ManagementCompanyId
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CustomerUpdatedConsumer : IConsumer<ICustomerUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public CustomerUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICustomerUpdated> context)
        {
            SourceCustomerUpdateCommand cmd = new SourceCustomerUpdateCommand()
            {
                Id = context.Message.Id,
                customerLocalityID = context.Message.CustomerLocalityId,
                customerTypeID = context.Message.CustomerTypeId,
                IsGovernment = context.Message.IsGovernment,
                IsInternational = context.Message.IsInternational,
                CustomerNameFriendly = context.Message.CustomerName,
                CustomerName = context.Message.CustomerName,
                managementCompanyID = context.Message.ManagementCompanyId
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CustomerDeletedConsumer : IConsumer<ICustomerDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public CustomerDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICustomerDeleted> context)
        {
            SourceCustomerDeleteCommand cmd = new SourceCustomerDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
