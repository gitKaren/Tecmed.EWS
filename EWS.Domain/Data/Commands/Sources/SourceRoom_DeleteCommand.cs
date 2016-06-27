using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceRoomDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceRoomDeleteCommand() { }
    }

    public class SourceRoomDeleteCommandHandler : ICommandHandler<SourceRoomDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceRoomDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceRoomDeleteCommand command)
        {
            var entity = new Room()
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
