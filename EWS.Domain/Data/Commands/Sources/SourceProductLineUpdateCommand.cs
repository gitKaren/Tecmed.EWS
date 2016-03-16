using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceProductLineUpdateCommand : CommandWithIdDefinition<int>
    {
        public SourceProductLineUpdateCommand() { }
        public string ProductLineName { get; set; }
        public string SupplierId { get; set; }
    }

    public class SourceProductLineUpdateCommandHandler : ICommandHandler<SourceProductLineUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceProductLineUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceProductLineUpdateCommand command)
        {
            var entity = _entities.Get<ProductLine>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new ProductLine()
                {
                    ID = command.Id,
                    supplierID = command.SupplierId,
                    ProductLineName = command.ProductLineName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.ProductLineName = command.ProductLineName;
                entity.supplierID = command.SupplierId;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
