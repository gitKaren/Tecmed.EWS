using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands
{
    public class QuoteCalculationSaveCommand : ICommandDefinition
    {
        public QuoteCalculationSaveCommand() { }
        public int ID { get; set; }
        public int QuoteID { get; set; }
        public short ContractTypeID { get; set; }
        public decimal SellingPricePerc { get; set; }
        public decimal SellingPricePercAmount { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ROEPortion { get; set; }
        public decimal ZARPortion { get; set; }
        public decimal ROEPortionAmount { get; set; }
        public decimal ZARPortionAmount { get; set; }

    }

    public class QuoteCalculationSaveCommandHandler : ICommandHandler<QuoteCalculationSaveCommand>
    {
        private readonly IEntityWriter _entities;

        public QuoteCalculationSaveCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(QuoteCalculationSaveCommand command)
        {
            var entity = _entities.Get<QuoteCalculation>().SingleOrDefault(p => p.ID == command.ID);
            if (entity == null)
            {
                entity = new QuoteCalculation()
                {
                    ID = command.ID,
                    QuoteID = command.QuoteID,
                    ContractTypeID = command.ContractTypeID,
                    SellingPricePerc = command.SellingPricePerc,
                    SellingPricePercAmount = command.SellingPricePercAmount,
                    BasePrice = command.BasePrice,
                    ROEPortion = command.ROEPortion,
                    ZARPortion = command.ZARPortion,
                    ROEPortionAmount = command.ROEPortionAmount,
                    ZARPortionAmount = command.ZARPortionAmount
            
                };
                _entities.Create(entity);
            }
            else
            {
                entity.QuoteID = command.QuoteID;
                entity.ContractTypeID = command.ContractTypeID;
                entity.SellingPricePerc = command.SellingPricePerc;
                entity.SellingPricePercAmount = command.SellingPricePercAmount;
                entity.BasePrice = command.BasePrice;
                entity.ROEPortion = command.ROEPortion;
                entity.ZARPortion = command.ZARPortion;
                entity.ROEPortionAmount = command.ROEPortionAmount;
                entity.ZARPortionAmount = command.ZARPortionAmount;
                
            }
            
            _entities.SaveChanges();
            command.ID = entity.ID;
        }
    }
}
