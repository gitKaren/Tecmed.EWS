using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceDeviceDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceDeviceDeleteCommand() { }
    }

    public class SourceDeviceDeleteCommandHandler : ICommandHandler<SourceDeviceDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceDeviceDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceDeviceDeleteCommand command)
        {
            var entity = new Device()
            {
                ID = command.Id
            };
            _entities.Delete(entity);

            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
