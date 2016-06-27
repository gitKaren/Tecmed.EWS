using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSiteDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceSiteDeleteCommand() { }
    }

    public class SourceSiteDeleteCommandHandler : ICommandHandler<SourceSiteDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSiteDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSiteDeleteCommand command)
        {
            var entity = new Site()
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
