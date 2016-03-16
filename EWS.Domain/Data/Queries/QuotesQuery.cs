using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class QuotesQuery : IQueryDefinition<IEnumerable<Quote>>
    {
        
    }

    public class QuotesQueryHandler : IQueryHandler<QuotesQuery, IEnumerable<Quote>>
    {
        private readonly IEntityReader _entities;

        public QuotesQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<Quote> Handle(QuotesQuery query)
        {
            return _entities.Query<Quote>().AsEnumerable<Quote>();           
        }
    }
}
