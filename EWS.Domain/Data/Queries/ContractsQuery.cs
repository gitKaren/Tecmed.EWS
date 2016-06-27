using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractsQuery : IQueryDefinition<IEnumerable<Contract>>
    {
        public string Keyword { get; set; }
    }

    public class ContractsQueryHandler : IQueryHandler<ContractsQuery, IEnumerable<Contract>>
    {
        private readonly IEntityReader _entities;

        public ContractsQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<Contract> Handle(ContractsQuery query)
        {
            string keyw = query.Keyword.ToLower();
            return _entities.Query<Contract>().Where(p=>
                                                        p.TenderNo.ToLower().Contains(keyw) ||
                                                        p.Device.ModelNumber.ToLower().Contains(keyw) ||
                                                        p.Device.SerialNo.ToLower().Contains(keyw));           
        }
    }
}
