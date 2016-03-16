using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCurrencyUpdateCommand : CommandWithIdDefinition<string>
    {
        public SourceCurrencyUpdateCommand() { }
        public string Symbol { get; set; }
        public string CurrencyName { get; set; }
        public double DefaultRateOfExchange { get; set; }
    }

    public class SourceCurrencyUpdateCommandHandler : ICommandHandler<SourceCurrencyUpdateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCurrencyUpdateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCurrencyUpdateCommand command)
        {
            var entity = _entities.Get<Currency>()
                .SingleOrDefault(p => p.ID == command.Id);

            if (entity == null)
            {
                entity = new Currency()
                {
                    ID = command.Id,
                    Symbol = command.Symbol,
                    DefaultRateOfExchange = command.DefaultRateOfExchange,
                    CurrencyName = command.CurrencyName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.CurrencyName = command.CurrencyName;
            }
            int rowsAffected = _entities.SaveChanges();
            if (rowsAffected > 0)
            {
            }
        }
    }
}
