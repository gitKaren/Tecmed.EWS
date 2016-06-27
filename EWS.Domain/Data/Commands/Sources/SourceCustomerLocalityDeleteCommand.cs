using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCustomerLocalityDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceCustomerLocalityDeleteCommand() { }
    }

    public class SourceCustomerLocalityDeleteCommandHandler : ICommandHandler<SourceCustomerLocalityDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCustomerLocalityDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCustomerLocalityDeleteCommand command)
        {
            var entity = new CustomerLocality()
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
