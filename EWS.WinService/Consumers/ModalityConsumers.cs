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
    public class ModalityCreatedConsumer : IConsumer<IModalityCreated>
    {
        private ICommandProcessor _commandProcessor;

        public ModalityCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IModalityCreated> context)
        {
            SourceModalityCreateCommand cmd = new SourceModalityCreateCommand()
            {
                Id = context.Message.Id,
                ModalityName = context.Message.ModalityName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class ModalityUpdatedConsumer : IConsumer<IModalityUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public ModalityUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IModalityUpdated> context)
        {
            SourceModalityUpdateCommand cmd = new SourceModalityUpdateCommand()
            {
                Id = context.Message.Id,
                ModalityName = context.Message.ModalityName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class ModalityDeletedConsumer : IConsumer<IModalityDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public ModalityDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IModalityDeleted> context)
        {
            SourceModalityDeleteCommand cmd = new SourceModalityDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
