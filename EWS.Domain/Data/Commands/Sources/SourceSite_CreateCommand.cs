using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSiteCreateCommand : CommandWithIdDefinition<int>
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

    public class SourceSiteCreateCommandHandler : ICommandHandler<SourceSiteCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSiteCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSiteCreateCommand command)
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
                int rowsAffected = _entities.SaveChanges();
                if (rowsAffected > 0)
                {
                }
            }
        }
    }
}
