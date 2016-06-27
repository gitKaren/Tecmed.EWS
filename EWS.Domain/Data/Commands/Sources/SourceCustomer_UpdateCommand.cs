using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCustomerUpdateCommand : CommandWithIdDefinition<int>
    {
        public SourceCustomerUpdateCommand() { }
        public string CustomerRef { get; set; }
        public string AccountRef { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNameFriendly { get; set; }
        public int customerTypeID { get; set; }
        public bool Deleted { get; set; }
        public string RegistrationNo { get; set; }
        public string PractiscId { get; set; }
        public string VATNo { get; set; }
        public int customerLocalityID { get; set; }
        public bool IsInternational { get; set; }
        public bool IsGovernment { get; set; }
        public Nullable<int> managementCompanyID { get; set; }
    }

    public class SourceCustomerUpdateCommandHandler : ICommandHandler<SourceCustomerUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCustomerUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCustomerUpdateCommand command)
        {
            var entity = _entities.Get<Customer>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Customer()
                {
                    ID = command.Id,
                    CustomerRef = command.CustomerRef,
                    AccountRef = command.AccountRef,
                    customerLocalityID = command.customerLocalityID,
                    CustomerName = command.CustomerName,
                    CustomerNameFriendly = command.CustomerNameFriendly,
                    customerTypeID = command.customerTypeID,
                    Deleted = command.Deleted,
                    IsGovernment = command.IsGovernment,
                    IsInternational = command.IsInternational,
                    managementCompanyID = command.managementCompanyID,
                    PractiscId = command.PractiscId,
                    RegistrationNo = command.RegistrationNo,
                    VATNo = command.VATNo
                };
                _entities.Create(entity);
            }
            else
            {
                 entity.CustomerRef = command.CustomerRef;
                    entity.AccountRef = command.AccountRef;
                    entity.customerLocalityID = command.customerLocalityID;
                    entity.CustomerName = command.CustomerName;
                    entity.CustomerNameFriendly = command.CustomerNameFriendly;
                    entity.customerTypeID = command.customerTypeID;
                    entity.Deleted = command.Deleted;
                    entity.IsGovernment = command.IsGovernment;
                    entity.IsInternational = command.IsInternational;
                    entity.managementCompanyID = command.managementCompanyID;
                    entity.PractiscId = command.PractiscId;
                    entity.RegistrationNo = command.RegistrationNo;
                    entity.VATNo = command.VATNo;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
