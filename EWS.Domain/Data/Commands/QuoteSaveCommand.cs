using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands
{
    public class QuoteSaveCommand : ICommandDefinition
    {
        public QuoteSaveCommand() { }
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int DeviceID { get; set; }
        public string TenderNo { get; set; }
        public string QuoteRef { get; set; }
        public int? BaseContractID { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ROE { get; set; }
        public System.DateTime ROEDate { get; set; }
        public float VAT { get; set; }
        public byte ContractTerm { get; set; }
        public bool Deleted { get; set; }
    }

    public class QuoteSaveCommandHandler : ICommandHandler<QuoteSaveCommand>
    {
        private readonly IEntityWriter _entities;

        public QuoteSaveCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(QuoteSaveCommand command)
        {
            var entity = _entities.Get<Quote>().SingleOrDefault(p => p.ID == command.ID);
            if (entity == null)
            {
                entity = new Quote()
                {
                    ID = command.ID,
                    CreateDate = DateTime.Now,
                    CustomerID = command.CustomerID,
                    DeviceID = command.DeviceID,
                    TenderNo = command.TenderNo,
                    QuoteRef = command.QuoteRef,
                    SellingPrice = command.SellingPrice,
                    BaseContractID = command.BaseContractID,
                    ROE = command.ROE,
                    ROEDate = command.ROEDate,
                    VAT = command.VAT,
                    ContractTerm = command.ContractTerm,
                    Deleted = command.Deleted                   
                };
                _entities.Create(entity);
            }
            else
            {
                entity.CustomerID = command.CustomerID;
                entity.DeviceID = command.DeviceID;
                entity.TenderNo = command.TenderNo;
                entity.QuoteRef = command.QuoteRef;
                entity.BaseContractID = command.BaseContractID;
                entity.SellingPrice = command.SellingPrice;
                entity.ROE = command.ROE;
                entity.ROEDate = command.ROEDate;
                entity.VAT = command.VAT;
                entity.ContractTerm = command.ContractTerm;
                entity.Deleted = command.Deleted;
            }
            
            _entities.SaveChanges();
            command.ID = entity.ID;

        }
    }
}
