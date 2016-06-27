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
    public class RoomCreatedConsumer : IConsumer<IRoomCreated>
    {
        private ICommandProcessor _commandProcessor;

        public RoomCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IRoomCreated> context)
        {

 
            SourceRoomCreateCommand cmd = new SourceRoomCreateCommand()
            {              
                Id = context.Message.Id,
                DepartmentId = context.Message.DepartmentId,
                RoomNo = context.Message.RoomNo
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class RoomUpdatedConsumer : IConsumer<IRoomUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public RoomUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IRoomUpdated> context)
        {
            SourceRoomUpdateCommand cmd = new SourceRoomUpdateCommand()
            {
                Id = context.Message.Id,
                DepartmentId = context.Message.DepartmentId,
                RoomNo = context.Message.RoomNo
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class RoomDeletedConsumer : IConsumer<IRoomDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public RoomDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IRoomDeleted> context)
        {
            SourceRoomDeleteCommand cmd = new SourceRoomDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
