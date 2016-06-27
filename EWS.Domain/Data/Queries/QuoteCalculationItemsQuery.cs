using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class QuoteCalculationItemsQuery : IQueryDefinition<IEnumerable<QuoteCalculationItem>>
    {
        public int QuoteCalculationID { get; set; }
    }

    public class QuoteCalculationItemsQueryHandler : IQueryHandler<QuoteCalculationItemsQuery, IEnumerable<QuoteCalculationItem>>
    {
        private readonly IEntityReader _entities;

        public QuoteCalculationItemsQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<QuoteCalculationItem> Handle(QuoteCalculationItemsQuery query)
        {
            return _entities.Query<QuoteCalculationItem>().Where<QuoteCalculationItem>(p => p.QuoteCalculationID == query.QuoteCalculationID)
                                                      .AsEnumerable<QuoteCalculationItem>();           
        }
    }
}
