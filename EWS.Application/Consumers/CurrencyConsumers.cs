using MassTransit;
using Spectrum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data;
using EWS.Domain.Data.Commands.Sources;

namespace TOPS.Application.Consumers
{
    public class CurrencyCreatedConsumer : IConsumer<ICurrencyCreated>
    {
        private ICommandProcessor _commandProcessor;

        public CurrencyCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICurrencyCreated> context)
        {
            SourceCurrencyCreateCommand cmd = new SourceCurrencyCreateCommand()
            {
                Id = context.Message.Id,
                DefaultRateOfExchange = context.Message.DefaultRateOfExchange,
                Symbol = context.Message.Symbol,
                CurrencyName = context.Message.CurrencyName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CurrencyUpdatedConsumer : IConsumer<ICurrencyUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public CurrencyUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICurrencyUpdated> context)
        {
            SourceCurrencyUpdateCommand cmd = new SourceCurrencyUpdateCommand()
            {
                Id = context.Message.Id,
                DefaultRateOfExchange = context.Message.DefaultRateOfExchange,
                Symbol = context.Message.Symbol,
                CurrencyName = context.Message.CurrencyName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CurrencyDeletedConsumer : IConsumer<ICurrencyDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public CurrencyDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICurrencyDeleted> context)
        {
            SourceCurrencyDeleteCommand cmd = new SourceCurrencyDeleteCommand()
            {
                Id = context.Message.Id
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
