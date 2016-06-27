using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceRoomUpdateCommand : CommandWithIdDefinition<int>
    {
        public int DepartmentId { get; set; }
        public int Id { get; set; }
        public string RoomNo { get; set; }
    }

    public class SourceRoomUpdateCommandHandler : ICommandHandler<SourceRoomUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceRoomUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceRoomUpdateCommand command)
        {
            var entity = _entities.Get<Room>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Room()
                {
                    ID = command.Id,
                    departmentID = command.DepartmentId,
                    RoomNo = command.RoomNo
                };
                _entities.Create(entity);
            }
            else
            {
                entity.ID = command.Id;
                entity.departmentID = command.DepartmentId;
                entity.RoomNo = command.RoomNo;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
