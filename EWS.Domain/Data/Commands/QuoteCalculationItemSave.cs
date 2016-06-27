using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands
{
    public class QuoteCalculationItemSaveCommand : ICommandDefinition
    {
        public QuoteCalculationItemSaveCommand() { }
        public int ID { get; set; }
        public int QuoteCalculationID { get; set; }
        public short YearNo { get; set; }
        public decimal ROEPortionAmount { get; set; }
        public decimal ZARPortionAmount { get; set; }
        public decimal ROE { get; set; }
        public decimal IncrPerc { get; set; }
        public decimal AmountInclVAT { get; set; }
        public decimal AmountExclVAT { get; set; }
    }

    public class QuoteCalculationItemSaveCommandHandler : ICommandHandler<QuoteCalculationItemSaveCommand>
    {
        private readonly IEntityWriter _entities;

        public QuoteCalculationItemSaveCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(QuoteCalculationItemSaveCommand command)
        {
            var entity = _entities.Get<QuoteCalculationItem>().SingleOrDefault(p => p.ID == command.ID);
            if (entity == null)
            {
                entity = new QuoteCalculationItem()
                {
                    ID = command.ID,
                    QuoteCalculationID = command.QuoteCalculationID,
                    YearNo = command.YearNo,
                    ROEPortionAmount = command.ROEPortionAmount,
                    ZARPortionAmount = command.ZARPortionAmount,
                    ROE = command.ROE,
                    IncrPerc = command.IncrPerc,
                    AmountInclVAT = command.AmountInclVAT,
                    AmountExclVAT = command.AmountExclVAT
                };
                _entities.Create(entity);
            }
            else
            {
                entity.QuoteCalculationID = command.QuoteCalculationID;
                entity.YearNo = command.YearNo;
                entity.ROEPortionAmount = command.ROEPortionAmount;
                entity.ZARPortionAmount = command.ZARPortionAmount;
                entity.ROE = command.ROE;
                entity.IncrPerc = command.IncrPerc;
                entity.AmountExclVAT = command.AmountExclVAT;
                entity.AmountInclVAT = command.AmountInclVAT;
            }
            
            _entities.SaveChanges();
            command.ID = entity.ID;
        }
    }
}
