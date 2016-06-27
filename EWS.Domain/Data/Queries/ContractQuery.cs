using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractQuery : IQueryDefinition<Contract>
    {
        public int ID { get; set; }

    }

    public class ContractQueryHandler : IQueryHandler<ContractQuery, Contract>
    {
        private readonly IEntityReader _entities;

        public ContractQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Contract Handle(ContractQuery query)
        {
            return _entities.Query<Contract>().FirstOrDefault(p => p.ID == query.ID);           
        }
    }
}
