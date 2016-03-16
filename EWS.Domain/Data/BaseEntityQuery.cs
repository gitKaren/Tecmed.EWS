using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EWS.Domain.Data
{
    public abstract class BaseEntityQuery<TEntity> where TEntity : DbEntity
    {
        public IEnumerable<Expression<Func<TEntity, object>>> EagerLoad { get; set; }
    }
}
