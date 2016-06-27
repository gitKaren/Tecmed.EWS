using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractItemQuery : IQueryDefinition<ContractItem>
    {
        public int ID { get; set; }

    }

    public class ContractItemQueryHandler : IQueryHandler<ContractItemQuery, ContractItem>
    {
        private readonly IEntityReader _entities;

        public ContractItemQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public ContractItem Handle(ContractItemQuery query)
        {
            return _entities.Query<ContractItem>().FirstOrDefault(p => p.ID == query.ID);           
        }
    }
}
