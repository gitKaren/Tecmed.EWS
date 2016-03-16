using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.Commands;
using EWS.Domain.Data.DataModel;


namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCountryDeleteCommand : CommandWithIdDefinition<string>
    {
        public SourceCountryDeleteCommand() { }
    }

    public class SourceCountryDeleteCommandHandler : ICommandHandler<SourceCountryDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCountryDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCountryDeleteCommand command)
        {
            var entity = new Country()
            {
                ISOCode = command.Id
            };
            _entities.Delete(entity);

            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
