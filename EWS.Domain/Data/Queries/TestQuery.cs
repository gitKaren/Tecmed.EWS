using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Model;

namespace EWS.Domain.Data.Queries
{
    public class TestQuery : IQueryDefinition<Test>
    {
        public Guid Id { get; set; }
    }

    public class TestQueryHandler : IQueryHandler<TestQuery, Test>
    {
        private readonly IEntityReader _entities;

        public TestQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Test Handle(TestQuery query)
        {
            var dbTest = _entities.Query<EWS.Domain.Data.DataModel.Test>().Single(p => p.ID == query.Id);
            return new Test(dbTest.ID, dbTest.Test1);
        }
    }
}
