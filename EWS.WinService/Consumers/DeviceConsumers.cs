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
    public class DeviceCreatedConsumer : IConsumer<IDeviceCreated>
    {
        private ICommandProcessor _commandProcessor;

        public DeviceCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IDeviceCreated> context)
        {
            SourceDeviceCreateCommand cmd = new SourceDeviceCreateCommand()
            {
                Id = context.Message.Id,
                deviceTypeID = context.Message.DeviceTypeId,
                ModelNumber = context.Message.ModelNumber,
                ProductLineID = context.Message.ProductLineId,
                roomID = context.Message.RoomId,
                SerialNo = context.Message.SerialNumber,
                submodalityID = context.Message.SubModalityId
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class DeviceUpdatedConsumer : IConsumer<IDeviceUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public DeviceUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IDeviceUpdated> context)
        {
            SourceDeviceUpdateCommand cmd = new SourceDeviceUpdateCommand()
            {
                Id = context.Message.Id,
                deviceTypeID = context.Message.DeviceTypeId,
                ModelNumber = context.Message.ModelNumber,
                ProductLineID = context.Message.ProductLineId,
                roomID = context.Message.RoomId,
                SerialNo = context.Message.SerialNumber,
                submodalityID = context.Message.SubModalityId
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class DeviceDeletedConsumer : IConsumer<IDeviceDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public DeviceDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<IDeviceDeleted> context)
        {
            SourceDeviceDeleteCommand cmd = new SourceDeviceDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
