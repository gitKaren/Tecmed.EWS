using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractItemsQuery : IQueryDefinition<IEnumerable<ContractItem>>
    {
        public int ContractID { get; set; }
    }

    public class ContractItemsQueryHandler : IQueryHandler<ContractItemsQuery, IEnumerable<ContractItem>>
    {
        private readonly IEntityReader _entities;

        public ContractItemsQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<ContractItem> Handle(ContractItemsQuery query)
        {
            return _entities.Query<ContractItem>().Where(p => p.ContractID == query.ContractID);           
        }
    }
}
