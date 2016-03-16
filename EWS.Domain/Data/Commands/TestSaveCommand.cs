using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Commands
{
    public class TestSaveCommand : ICommandDefinition
    {
        public TestSaveCommand() { }
        public Guid Id { get; set; }
        public string TestName { get; set; }
    }

    public class TestSaveCommandHandler : ICommandHandler<TestSaveCommand>
    {
        private readonly IEntityWriter _entities;

        public TestSaveCommandHandler(IEntityWriter entities)
        {
            _entities = entities;
        }

        public void Handle(TestSaveCommand command)
        {
            var entity = _entities.Get<Test>().SingleOrDefault(p => p.ID == command.Id);
            if (entity == null)
            {
                entity = new Test()
                {
                    ID = command.Id,
                    Test1 = command.TestName
                };
                _entities.Create(entity);
            }
            else
            {
                entity.Test1 = command.TestName;
            }
            
            _entities.SaveChanges();
        }
    }
}
