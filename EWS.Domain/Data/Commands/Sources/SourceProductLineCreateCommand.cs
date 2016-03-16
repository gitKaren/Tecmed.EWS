using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceProductLineCreateCommand : CommandWithIdDefinition<int>
    {
        public SourceProductLineCreateCommand() { }
        public string SupplierId { get; set; }
        public string ProductLineName { get; set; }
    }

    public class SourceProductLineCreateCommandHandler : ICommandHandler<SourceProductLineCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceProductLineCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceProductLineCreateCommand command)
        {
            var entity = _entities.Get<ProductLine>()
                .SingleOrDefault(p => p.ProductLineName == command.ProductLineName && p.supplierID == command.SupplierId);

            if (entity == null)
            {
                entity = new ProductLine()
                {
                    ID = command.Id,
                    supplierID = command.SupplierId,
                    ProductLineName = command.ProductLineName
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
