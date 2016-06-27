using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSiteUpdateCommand : CommandWithIdDefinition<int>
    {
        public int CustomerId { get; set; }
        public string SiteRef { get; set; }
        public string SiteName { get; set; }
        public int MarketSegmentId { get; set; }
        public int SupportBranchId { get; set; }
        public string RegistrationNumber { get; set; }
        public string VATNumber { get; set; }
        public bool Deleted { get; set; }
    }

    public class SourceSiteUpdateCommandHandler : ICommandHandler<SourceSiteUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSiteUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSiteUpdateCommand command)
        {
            var entity = _entities.Get<Site>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Site()
                {
                    ID = command.Id,
                    marketSegmentID = command.MarketSegmentId,
                    customerID = command.CustomerId,
                    RegistrationNo = command.RegistrationNumber,
                    SiteRef = command.SiteRef,
                    SiteName = command.SiteName,
                    supportBranchID = command.SupportBranchId,
                    VATNo = command.VATNumber,
                    Deleted = command.Deleted
                };
                _entities.Create(entity);
            }
            else
            {
                entity.marketSegmentID = command.MarketSegmentId;
                entity.customerID = command.CustomerId;
                entity.RegistrationNo = command.RegistrationNumber;
                entity.SiteRef = command.SiteRef;
                entity.SiteName = command.SiteName;
                entity.supportBranchID = command.SupportBranchId;
                entity.VATNo = command.VATNumber;
                entity.Deleted = command.Deleted;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
