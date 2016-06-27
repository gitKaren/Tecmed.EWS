using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractTermQuery : IQueryDefinition<ContractTerm>
    {
        public byte NoOfMonths { get; set; }

    }

    public class ContractTermQueryHandler : IQueryHandler<ContractTermQuery, ContractTerm>
    {
        private readonly IEntityReader _entities;

        public ContractTermQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public ContractTerm Handle(ContractTermQuery query)
        {
            return _entities.Query<ContractTerm>().FirstOrDefault(p => p.NoOfMonths == query.NoOfMonths);           
        }
    }
}
