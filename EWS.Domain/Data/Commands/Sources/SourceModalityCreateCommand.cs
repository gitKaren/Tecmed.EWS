using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceModalityCreateCommand : CommandWithIdDefinition<string>
    {
        public SourceModalityCreateCommand() { }
        public string ModalityName { get; set; }
    }

    public class SourceModalityCreateCommandHandler : ICommandHandler<SourceModalityCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceModalityCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceModalityCreateCommand command)
        {
            var entity = _entities.Get<Modality>()
                .SingleOrDefault(p => p.ID.ToString() == command.Id);

            if (entity == null)
            {
                entity = new Modality()
                {
                    ID = command.Id,
                    ModalityName = command.ModalityName
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
