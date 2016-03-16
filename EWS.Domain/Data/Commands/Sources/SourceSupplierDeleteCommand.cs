using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSupplierDeleteCommand : CommandWithIdDefinition<string>
    {
        public SourceSupplierDeleteCommand() { }
    }

    public class SourceSupplierDeleteCommandHandler : ICommandHandler<SourceSupplierDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSupplierDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSupplierDeleteCommand command)
        {
            var entity = new Supplier()
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
