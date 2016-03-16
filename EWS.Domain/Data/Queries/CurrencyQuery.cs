using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EWS.Domain.Model;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class CurrencyQuery : IQueryDefinition<Currency>
    {
        public string ID { get; set; }

    }

    public class CurrencyQueryHandler : IQueryHandler<CurrencyQuery, Currency>
    {
        private readonly IEntityReader _entities;

        public CurrencyQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Currency Handle(CurrencyQuery query)
        {
            Currency entity =
                _entities.Query<Currency>()
                    .Where(p => p.ID.ToLower().Contains(query.ID.ToLower())
                           ).FirstOrDefault<Currency>();


            return entity;
        }
    }
}
