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
    public class SubModalityCreatedConsumer : IConsumer<ISubModalityCreated>
    {
        private ICommandProcessor _commandProcessor;

        public SubModalityCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISubModalityCreated> context)
        {
            //SourceSubModalityCreateCommand cmd = new SourceSubModalityCreateCommand()
            //{
            //    Id = context.Message.Id,
            //    ProductClassification = context.Message.ProductClassification,
            //    ModalityId = context.Message.ModalityId,
            //    SubModalityName = context.Message.SubModalityName
            //};
            //_commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class SubModalityUpdatedConsumer : IConsumer<ISubModalityUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public SubModalityUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISubModalityUpdated> context)
        {
            //SourceSubModalityUpdateCommand cmd = new SourceSubModalityUpdateCommand()
            //{
            //    Id = context.Message.Id,
            //    ProductClassification = context.Message.ProductClassification,
            //    ModalityId = context.Message.ModalityId,
            //    SubModalityName = context.Message.SubModalityName
            //};
            //_commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class SubModalityDeletedConsumer : IConsumer<ISubModalityDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public SubModalityDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ISubModalityDeleted> context)
        {
            //SourceSubModalityDeleteCommand cmd = new SourceSubModalityDeleteCommand()
            //{
            //    Id = context.Message.Id
            //};
            //_commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
