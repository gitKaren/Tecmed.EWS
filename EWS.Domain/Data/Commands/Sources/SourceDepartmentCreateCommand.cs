using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceDepartmentCreateCommand : CommandWithIdDefinition<int>
    {
        public SourceDepartmentCreateCommand() { }
        public int siteID { get; set; }
        public string hospitalDepartmentID { get; set; }
        public string ResponsibleUserName { get; set; }
        public bool Deleted { get; set; }
    }

    public class SourceDepartmentCreateCommandHandler : ICommandHandler<SourceDepartmentCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceDepartmentCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceDepartmentCreateCommand command)
        {
            var entity = _entities.Get<Department>()
                .SingleOrDefault(p => p.ID == command.Id );

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
                int rowsAffected = _entities.SaveChanges();
                if (rowsAffected > 0)
                {
                }
            }
        }
    }
}
