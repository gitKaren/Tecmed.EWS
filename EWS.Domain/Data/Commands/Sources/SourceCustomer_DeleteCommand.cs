using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCustomerDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceCustomerDeleteCommand() { }
    }

    public class SourceCustomerDeleteCommandHandler : ICommandHandler<SourceCustomerDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCustomerDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCustomerDeleteCommand command)
        {
            var entity = new Customer()
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
