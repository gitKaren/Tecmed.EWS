using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCustomerLocalityUpdateCommand : CommandWithIdDefinition<int>
    {
        public SourceCustomerLocalityUpdateCommand() { }
        public string CustomerLocalityName { get; set; }
        public string SupplierId { get; set; }
    }

    public class SourceCustomerLocalityUpdateCommandHandler : ICommandHandler<SourceCustomerLocalityUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCustomerLocalityUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCustomerLocalityUpdateCommand command)
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
            }
            else
            {
                entity.CustomerLocalityName = command.CustomerLocalityName;
               
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
