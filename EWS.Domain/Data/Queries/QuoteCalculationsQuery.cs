using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class QuoteCalculationsQuery : IQueryDefinition<IEnumerable<QuoteCalculation>>
    {
        public int QuoteID { get; set; }
    }

    public class QuoteCalculationsQueryHandler : IQueryHandler<QuoteCalculationsQuery, IEnumerable<QuoteCalculation>>
    {
        private readonly IEntityReader _entities;

        public QuoteCalculationsQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<QuoteCalculation> Handle(QuoteCalculationsQuery query)
        {
            return _entities.Query<QuoteCalculation>().Where<QuoteCalculation>(p => p.QuoteID == query.QuoteID)
                                                      .AsEnumerable<QuoteCalculation>();           
        }
    }
}
