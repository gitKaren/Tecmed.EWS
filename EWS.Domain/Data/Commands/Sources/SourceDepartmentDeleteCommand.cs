using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceDepartmentDeleteCommand : CommandWithIdDefinition<int>
    {
        public SourceDepartmentDeleteCommand() { }
    }

    public class SourceDepartmentDeleteCommandHandler : ICommandHandler<SourceDepartmentDeleteCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceDepartmentDeleteCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceDepartmentDeleteCommand command)
        {
            var entity = new Department()
            {
                ID = command.Id
            };
            _entities.Delete(entity);

            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
