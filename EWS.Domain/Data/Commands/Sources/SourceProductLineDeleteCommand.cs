using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceProductLineDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceProductLineDeleteCommand() { }
    }

    public class SourceProductLineDeleteCommandHandler : ICommandHandler<SourceProductLineDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceProductLineDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceProductLineDeleteCommand command)
        {
            var entity = new ProductLine()
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
