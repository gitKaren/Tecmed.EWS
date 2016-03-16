using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceSubModalityUpdateCommand : CommandWithIdDefinition<Guid>
    {
        public SourceSubModalityUpdateCommand() { }
        public string ProductClassification { get; set; }
        public string ModalityId { get; set; }
        public string SubModalityName { get; set; }
    }

    public class SourceSubModalityUpdateCommandHandler : ICommandHandler<SourceSubModalityUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceSubModalityUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceSubModalityUpdateCommand command)
        {
            var entity = _entities.Get<SubModality>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new SubModality()
                {
                    ID = command.Id,
                    modalityID = command.ModalityId,
                    ProductClassification = command.ProductClassification,
                    SubModalityName = command.SubModalityName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.SubModalityName = command.SubModalityName;
                entity.modalityID = command.ModalityId;
                entity.ProductClassification = command.ProductClassification;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
