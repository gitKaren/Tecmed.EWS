using Spectrum.SharedKernel.Authorisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data;
using EWS.Domain.Data.Commands;
using EWS.Domain.Data.Queries;
using EWS.Domain.DomainServices;
using EWS.Domain.Model;

namespace EWS.Application.Services
{
    public class ContractService
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private ICurrentUserFactory _currentUserFactory;

        public ContractService(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory)
        {
            if (currentUserFactory == null) throw new ArgumentNullException("CurrentUserFactory cannot be null");
            if (commandProcessor == null) throw new ArgumentNullException("Command Processor cannot be null");
            if (queryProcessor == null) throw new ArgumentNullException("Query Processor cannot be null");
            _currentUserFactory = currentUserFactory;
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public Device[] GetCoveredItems(int QuoteID)
        {
            QuoteQuery quotequery = new QuoteQuery() { ID = QuoteID };
            EWS.Domain.Data.DataModel.Quote quote = _queryProcessor.Execute(quotequery);

            DeviceQuery devicequery = new DeviceQuery() { DeviceID = quote.DeviceID };
            EWS.Domain.Model.Device device = _queryProcessor.Execute(devicequery);

            return new Device[1] { device };    //Todo finish this so it returns the individual components

        }


        public EWS.Domain.Data.DataModel.ContractInclusion[] GetContractInclusions(int QuoteID)
        {
            QuoteQuery quotequery = new QuoteQuery() { ID = QuoteID };
            EWS.Domain.Data.DataModel.Quote quote = _queryProcessor.Execute(quotequery);

            DeviceQuery devicequery = new DeviceQuery() { DeviceID = quote.DeviceID };
            EWS.Domain.Model.Device device = _queryProcessor.Execute(devicequery);

            ContractInclusionsQuery inclquery = new ContractInclusionsQuery() { ModalityID = device.ModalityID };
            IEnumerable<EWS.Domain.Data.DataModel.ContractInclusion> result1 = _queryProcessor.Execute(inclquery);

            inclquery = new ContractInclusionsQuery() { ModalityID = null };
            IEnumerable<EWS.Domain.Data.DataModel.ContractInclusion> result2 = _queryProcessor.Execute(inclquery);


            EWS.Domain.Data.DataModel.ContractInclusion[] inclusions = result1.Concat(result2).ToArray();


            return inclusions;

        }
      
    }
}
