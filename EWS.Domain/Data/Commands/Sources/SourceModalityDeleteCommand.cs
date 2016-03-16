using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceModalityDeleteCommand : CommandWithIdDefinition<string>
    {
        public SourceModalityDeleteCommand() { }
    }

    public class SourceModalityDeleteCommandHandler : ICommandHandler<SourceModalityDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceModalityDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceModalityDeleteCommand command)
        {
            var entity = new Modality()
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
