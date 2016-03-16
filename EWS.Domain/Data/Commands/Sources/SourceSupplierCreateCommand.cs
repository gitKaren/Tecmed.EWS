using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSupplierCreateCommand : CommandWithIdDefinition<string>
    {
        public SourceSupplierCreateCommand() { }
        public string SupplierName { get; set; }
    }

    public class SourceSupplierCreateCommandHandler : ICommandHandler<SourceSupplierCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSupplierCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSupplierCreateCommand command)
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
                int rowsAffected = _entities.SaveChanges();
                if (rowsAffected > 0)
                {
                }
            }
        }
    }
}
