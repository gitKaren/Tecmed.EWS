using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractTypeQuery : IQueryDefinition<ContractType>
    {
        public short ID { get; set; }
    }

    public class ContractTypeQueryHandler : IQueryHandler<ContractTypeQuery, ContractType>
    {
        private readonly IEntityReader _entities;

        public ContractTypeQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public ContractType Handle(ContractTypeQuery query)
        {
            return _entities.Query<ContractType>().Single(p => p.ID == query.ID);           
        }
    }
}
