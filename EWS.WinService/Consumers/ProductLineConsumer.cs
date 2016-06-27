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
    public class ProductLineCreatedConsumer : IConsumer<IProductLineCreated>
    {
        private ICommandProcessor _commandProcessor;

        public ProductLineCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IProductLineCreated> context)
        {
            SourceProductLineCreateCommand cmd = new SourceProductLineCreateCommand()
            {
                Id = context.Message.Id,
                SupplierId = context.Message.SupplierId,
                ProductLineName = context.Message.ProductLineName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class ProductLineUpdatedConsumer : IConsumer<IProductLineUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public ProductLineUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IProductLineUpdated> context)
        {
            SourceProductLineUpdateCommand cmd = new SourceProductLineUpdateCommand()
            {
                Id = context.Message.Id,
                SupplierId = context.Message.SupplierId,
                ProductLineName = context.Message.ProductLineName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class ProductLineDeletedConsumer : IConsumer<IProductLineDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public ProductLineDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IProductLineDeleted> context)
        {
            SourceProductLineDeleteCommand cmd = new SourceProductLineDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
