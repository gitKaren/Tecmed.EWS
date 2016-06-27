using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class ContractInclusionsQuery : IQueryDefinition<IEnumerable<ContractInclusion>>
    {
        public string ModalityID { get; set; }
    }

    public class ContractInclusionsQueryHandler : IQueryHandler<ContractInclusionsQuery, IEnumerable<ContractInclusion>>
    {
        private readonly IEntityReader _entities;

        public ContractInclusionsQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<ContractInclusion> Handle(ContractInclusionsQuery query)
        {
            return _entities.Query<ContractInclusion>().Where(i => (i.ModalityID == query.ModalityID && !string.IsNullOrEmpty(query.ModalityID) )
                                                                || (string.IsNullOrEmpty(i.ModalityID) && string.IsNullOrEmpty(query.ModalityID) )
                                                              ).AsEnumerable<ContractInclusion>();           
        }
    }
}
