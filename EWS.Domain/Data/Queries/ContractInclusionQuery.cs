using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractInclusionQuery : IQueryDefinition<ContractInclusion>
    {
        public short ID { get; set; }
    }

    public class ContractInclusionQueryHandler : IQueryHandler<ContractInclusionQuery, ContractInclusion>
    {
        private readonly IEntityReader _entities;

        public ContractInclusionQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public ContractInclusion Handle(ContractInclusionQuery query)
        {
            return _entities.Query<ContractInclusion>().Single(p => p.ID == query.ID);           
        }
    }
}
