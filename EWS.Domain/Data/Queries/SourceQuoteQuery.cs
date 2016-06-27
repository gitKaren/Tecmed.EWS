using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EWS.Domain.Model;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class SourceQuoteQuery : IQueryDefinition<Domain.Model.SourceQuote>
    {
        public string QuoteRef { get; set; }

    }

    public class SourceQuoteQueryHandler : IQueryHandler<SourceQuoteQuery, Domain.Model.SourceQuote>
    {
        private readonly IEntityReader _entities;

        public SourceQuoteQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Domain.Model.SourceQuote Handle(SourceQuoteQuery query)
        {
            SourceQuote entity =
                _entities.Query<SourceQuote>()
                    .Where(p => p.Ref.ToLower() == query.QuoteRef.ToLower()
                           ).FirstOrDefault<SourceQuote>();
            List<Domain.Model.SourceQuote> models = new List<Domain.Model.SourceQuote>();

            if (entity == null)
                return null;
            else
            {
                Domain.Model.SourceQuote model = new Domain.Model.SourceQuote()
                                                            {
                                                                Date = entity.Date,
                                                                DeviceID = entity.DeviceID,
                                                                DeviceDescription = entity.DeviceID.ToString(),
                                                                QuoteRef = entity.Ref,
                                                                Supplier = entity.Supplier.SupplierName,
                                                                SellingPriceInclVAT = entity.SellingPriceInclVAT,
                                                                VAT = entity.VAT,
                                                                TenderNumber = entity.TenderNumber,
                                                                ROE = entity.ROE,
                                                                ROEDate = entity.ROEDate

                                                            };
                return model;
            }
            
        }
    }
}
