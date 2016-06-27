using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EWS.Domain.Model;
using EWS.Domain.Data.DataModel;

namespace EWS.Domain.Data.Queries
{
    public class CustomerQuery : IQueryDefinition<Customer>
    {
        public int  ID { get; set; }
    }

    public class CustomerQueryHandler : IQueryHandler<CustomerQuery, Customer>
    {
        private readonly IEntityReader _entities;

        public CustomerQueryHandler(IEntityReader entities)
        {
            _entities = entities;
        }

        public Customer Handle(CustomerQuery query)
        {
            Customer entity =
                _entities.Query<Customer>()
                    .Where(p => p.ID == query.ID)
                           .SingleOrDefault<Customer>();


            return entity;
        }
    }
}
