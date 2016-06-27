using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCustomerLocalityCreateCommand : CommandWithIdDefinition<int>
    {
        public SourceCustomerLocalityCreateCommand() { }
        public string SupplierId { get; set; }
        public string CustomerLocalityName { get; set; }
    }

    public class SourceCustomerLocalityCreateCommandHandler : ICommandHandler<SourceCustomerLocalityCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCustomerLocalityCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCustomerLocalityCreateCommand command)
        {
            var entity = _entities.Get<CustomerLocality>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new CustomerLocality()
                {
                    ID = command.Id,
                    CustomerLocalityName = command.CustomerLocalityName
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
