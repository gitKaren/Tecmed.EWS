using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSupplierUpdateCommand : CommandWithIdDefinition<string>
    {
        public SourceSupplierUpdateCommand() { }
        public string SupplierName { get; set; }
    }

    public class SourceSupplierUpdateCommandHandler : ICommandHandler<SourceSupplierUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSupplierUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSupplierUpdateCommand command)
        {
            var entity = _entities.Get<Supplier>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Supplier()
                {
                    ID = command.Id,
                    SupplierName = command.SupplierName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.SupplierName = command.SupplierName;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
