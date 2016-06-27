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
using EWS.Domain.Core;

namespace EWS.Application.Services
{
    public class AdminService
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private ICurrentUserFactory _currentUserFactory;

        public AdminService(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory)
        {
            if (currentUserFactory == null) throw new ArgumentNullException("CurrentUserFactory cannot be null");
            if (commandProcessor == null) throw new ArgumentNullException("Command Processor cannot be null");
            if (queryProcessor == null) throw new ArgumentNullException("Query Processor cannot be null");

            _currentUserFactory = currentUserFactory;
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public EWS.Domain.Data.DataModel.ContractInclusion[] GetContractInclusionsList()
        {
            ContractInclusionsQuery qry = new ContractInclusionsQuery();
            return _queryProcessor.Execute(qry).ToArray();           
        }

        public EWS.Domain.Data.DataModel.ContractInclusion GetContractInclusion(short id)
        {
            ContractInclusionQuery qry = new ContractInclusionQuery() { ID = id };
            return _queryProcessor.Execute(qry);  
        }

        public bool CreateContractInclusion( string Description)
        {
            return false; 
        }

        public bool UpdateContractInclusion(short ID, string Description)
        {
            return false; 
        }
    }
}
