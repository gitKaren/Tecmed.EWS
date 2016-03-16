using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands.Sources
{
    public class SourceCurrencyCreateCommand : CommandWithIdDefinition<string>
    {
        public SourceCurrencyCreateCommand() { }
        public string Symbol { get; set; }
        public string CurrencyName { get; set; }
        public double DefaultRateOfExchange { get; set; }
    }

    public class SourceCurrencyCreateCommandHandler : ICommandHandler<SourceCurrencyCreateCommand>
    {
        private readonly IEntityWriter _entities;

        public SourceCurrencyCreateCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(SourceCurrencyCreateCommand command)
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
                int rowsAffected = _entities.SaveChanges();
                if (rowsAffected > 0)
                {
                }
            }
        }
    }
}
