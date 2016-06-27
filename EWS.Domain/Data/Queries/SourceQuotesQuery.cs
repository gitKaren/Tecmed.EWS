using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EWS.Domain.Model;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class SourceQuotesQuery : IQueryDefinition<IEnumerable<EWS.Domain.Model.SourceQuote>>
    {
        public string QuoteRef { get; set; }

    }

    public class SourceQuotesQueryHandler : IQueryHandler<SourceQuotesQuery, IEnumerable<EWS.Domain.Model.SourceQuote>>
    {
        private readonly IEntityReader _entities;

        public SourceQuotesQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public IEnumerable<EWS.Domain.Model.SourceQuote> Handle(SourceQuotesQuery query)
        {
            IEnumerable<SourceQuote> dataList = 
                _entities.Query<SourceQuote>()
                    .Where(p => query.QuoteRef == null || p.Ref.ToLower().Contains(query.QuoteRef.ToLower())
                           ).AsEnumerable();

            List<Domain.Model.SourceQuote> models = new List<Domain.Model.SourceQuote>();


            foreach (SourceQuote item in dataList)
            {
                Domain.Model.SourceQuote model = new Domain.Model.SourceQuote()
                                                            { Date = item.Date, 
                                                              DeviceID = item.DeviceID,
                                                              DeviceDescription = item.DeviceID.ToString(),
                                                              QuoteRef = item.Ref,
                                                              Supplier = item.Supplier.SupplierName,
                                                              VAT = item.VAT,
                                                              TenderNumber = item.TenderNumber};
                models.Add(model);
            }

            return models;
        }
    }
}
