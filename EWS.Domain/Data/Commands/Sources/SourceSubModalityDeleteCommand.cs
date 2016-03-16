using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSubModalityDeleteCommand : CommandWithIdDefinition<Guid>
    {
        public SourceSubModalityDeleteCommand() { }
    }

    public class SourceSubModalityDeleteCommandHandler : ICommandHandler<SourceSubModalityDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSubModalityDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSubModalityDeleteCommand command)
        {
            var entity = new SubModality()
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
