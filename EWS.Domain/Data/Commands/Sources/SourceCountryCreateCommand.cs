using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCountryCreateCommand : CommandWithIdDefinition<string>
    {
        public SourceCountryCreateCommand() { }
        public string CurrencyId { get; set; }
        public string CountryName { get; set; }
    }

    public class SourceCountryCreateCommandHandler : ICommandHandler<SourceCountryCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCountryCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCountryCreateCommand command)
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
                int rowsAffected = _entities.SaveChanges();
                if (rowsAffected > 0)
                {
                }
            }
        }
    }
}
