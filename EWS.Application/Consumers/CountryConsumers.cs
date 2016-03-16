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
    public class CountryCreatedConsumer : IConsumer<ICountryCreated>
    {
        private ICommandProcessor _commandProcessor;

        public CountryCreatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICountryCreated> context)
        {
            SourceCountryCreateCommand cmd = new SourceCountryCreateCommand()
            {
                Id = context.Message.ISOCode,
                CurrencyId = context.Message.CurrencyId,
                CountryName = context.Message.CountryName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CountryUpdatedConsumer : IConsumer<ICountryUpdated>
    {
        private ICommandProcessor _commandProcessor;

        public CountryUpdatedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICountryUpdated> context)
        {
            SourceCountryUpdateCommand cmd = new SourceCountryUpdateCommand()
            {
                Id = context.Message.ISOCode,
                CurrencyId = context.Message.CurrencyId,
                CountryName = context.Message.CountryName
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }

    public class CountryDeletedConsumer : IConsumer<ICountryDeleted>
    {
        private ICommandProcessor _commandProcessor;

        public CountryDeletedConsumer(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public Task Consume(ConsumeContext<ICountryDeleted> context)
        {
            SourceCountryDeleteCommand cmd = new SourceCountryDeleteCommand()
            {
                Id = context.Message.ISOCode
            };
            _commandProcessor.Execute(cmd);

            return Task.FromResult(0);
        }
    }
}
