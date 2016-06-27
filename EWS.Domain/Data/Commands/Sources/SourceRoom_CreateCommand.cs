using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceRoomCreateCommand : CommandWithIdDefinition<int>
    {
        public int DepartmentId { get; set; }
        public int Id { get; set; }
        public string RoomNo { get; set; }
    }

    public class SourceRoomCreateCommandHandler : ICommandHandler<SourceRoomCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceRoomCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceRoomCreateCommand command)
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
                int rowsAffected = _entities.SaveChanges();
                if (rowsAffected > 0)
                {
                }
            }
        }
    }
}
