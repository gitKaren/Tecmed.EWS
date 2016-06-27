using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceDepartmentUpdateCommand : CommandWithIdDefinition<int>
    {
        public SourceDepartmentUpdateCommand() { }
        public int siteID { get; set; }
        public string hospitalDepartmentID { get; set; }
        public string ResponsibleUserName { get; set; }
        public bool Deleted { get; set; }
    }

    public class SourceDepartmentUpdateCommandHandler : ICommandHandler<SourceDepartmentUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceDepartmentUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceDepartmentUpdateCommand command)
        {
            var entity = _entities.Get<Department>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Department()
                {
                    ID = command.Id,
                    hospitalDepartmentID = command.hospitalDepartmentID,
                    ResponsibleUserName = command.ResponsibleUserName,
                    siteID = command.siteID,
                    Deleted = command.Deleted
                };
                _entities.Create(entity);
            }
            else
            {
                entity.hospitalDepartmentID = command.hospitalDepartmentID;
                entity.ResponsibleUserName = command.ResponsibleUserName;
                entity.siteID = command.siteID;
                entity.Deleted = command.Deleted;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
