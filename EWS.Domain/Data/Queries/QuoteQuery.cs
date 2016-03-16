using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class QuoteQuery : IQueryDefinition<Quote>
    {
        public int ID { get; set; }
        public string QuoteRef { get; set; }
    }

    public class QuoteQueryHandler : IQueryHandler<QuoteQuery, Quote>
    {
        private readonly IEntityReader _entities;

        public QuoteQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Quote Handle(QuoteQuery query)
        {
            return _entities.Query<Quote>().First(p => (p.ID == query.ID || query.ID == 0) 
                                                         && (p.QuoteRef == query.QuoteRef || string.IsNullOrEmpty(query.QuoteRef) )
                                                   );           
        }
    }
}
