using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCurrencyDeleteCommand : CommandWithIdDefinition<string>
    {
        public SourceCurrencyDeleteCommand() { }
    }

    public class SourceCurrencyDeleteCommandHandler : ICommandHandler<SourceCurrencyDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCurrencyDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCurrencyDeleteCommand command)
        {
            var entity = new Currency()
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
