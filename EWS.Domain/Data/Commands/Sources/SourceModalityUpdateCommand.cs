using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceModalityUpdateCommand : CommandWithIdDefinition<string>
    {
        public SourceModalityUpdateCommand() { }
        public string ModalityName { get; set; }
    }

    public class SourceModalityUpdateCommandHandler : ICommandHandler<SourceModalityUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceModalityUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceModalityUpdateCommand command)
        {
            var entity = _entities.Get<Modality>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Modality()
                {
                    ID = command.Id,
                    ModalityName = command.ModalityName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.ModalityName = command.ModalityName;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
