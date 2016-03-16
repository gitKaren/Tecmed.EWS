using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractTypesQuery : IQueryDefinition<IEnumerable<ContractType>>
    {
        public short ID { get; set; }
    }

    public class ContractTypesQueryHandler : IQueryHandler<ContractTypesQuery, IEnumerable<ContractType>>
    {
        private readonly IEntityReader _entities;

        public ContractTypesQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<ContractType> Handle(ContractTypesQuery query)
        {
            return _entities.Query<ContractType>().AsEnumerable<ContractType>();           
        }
    }
}
