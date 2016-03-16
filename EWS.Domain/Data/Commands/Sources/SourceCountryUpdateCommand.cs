using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCountryUpdateCommand : CommandWithIdDefinition<string>
    {
        public SourceCountryUpdateCommand() { }
        public string CurrencyId { get; set; }
        public string CountryName { get; set; } 
    }

    public class SourceCountryUpdateCommandHandler : ICommandHandler<SourceCountryUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCountryUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCountryUpdateCommand command)
        {
            var entity = _entities.Get<Country>()
                .SingleOrDefault(p => p.ISOCode == command.Id);

            if (entity == null)
            {
                entity = new Country()
                {
                    ISOCode = command.Id,
                    CurrencyID = command.CurrencyId,
                    CountryName = command.CountryName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.CurrencyID = command.CurrencyId;
                entity.CountryName = command.CountryName;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
