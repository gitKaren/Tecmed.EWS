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

namespace EWS.Application
{
    public class DeviceService
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private ICurrentUserFactory _currentUserFactory;

        public DeviceService(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory)
        {
            if (currentUserFactory == null) throw new ArgumentNullException("CurrentUserFactory cannot be null");
            if (commandProcessor == null) throw new ArgumentNullException("Command Processor cannot be null");
            if (queryProcessor == null) throw new ArgumentNullException("Query Processor cannot be null");
            _currentUserFactory = currentUserFactory;
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public EWS.Domain.Model.Device[] GetComponents(int DeviceID)
        {
            throw new NotImplementedException();
        }

    }
}
