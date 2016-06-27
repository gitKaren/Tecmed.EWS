using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractTermsQuery : IQueryDefinition<IEnumerable<ContractTerm>>
    {

    }

    public class ContractTermsQueryHandler : IQueryHandler<ContractTermsQuery, IEnumerable<ContractTerm>>
    {
        private readonly IEntityReader _entities;

        public ContractTermsQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<ContractTerm> Handle(ContractTermsQuery query)
        {
            return _entities.Query<ContractTerm>().AsEnumerable<ContractTerm>();           
        }
    }
}
