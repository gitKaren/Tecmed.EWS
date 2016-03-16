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
    public class TestService
    {
        private ICommandProcessor _commandProcessor;
        private IQueryProcessor _queryProcessor;
        private ICurrentUserFactory _currentUserFactory;

        public TestService(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor, ICurrentUserFactory currentUserFactory)
        {
            if (currentUserFactory == null) throw new ArgumentNullException("CurrentUserFactory cannot be null");
            if (commandProcessor == null) throw new ArgumentNullException("Command Processor cannot be null");
            if (queryProcessor == null) throw new ArgumentNullException("Query Processor cannot be null");
            _currentUserFactory = currentUserFactory;
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public string CreateTestAndReturnName(string testName)
        {
            if (AuthCheck.NewCheck().MustBeInRole("Dev").IsNotSatisfiedBy(_currentUserFactory.GetCurrentUser()))
            {
                throw new UserNotAuthorisedException();
            }

            Guid newTestId = Guid.NewGuid();
            TestSaveCommand cmd = new TestSaveCommand()
            {
                Id = newTestId,
                TestName = testName
            };
            _commandProcessor.Execute(cmd);


            TestQuery qry = new TestQuery()
            {
                Id = newTestId
            };

            Test domainEntity = _queryProcessor.Execute(qry);

            if (domainEntity != null)
                return domainEntity.TestName;
            else
                throw new Exception("Couldn't get test from database.");
        }
    }
}
