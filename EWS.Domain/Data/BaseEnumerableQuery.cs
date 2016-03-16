using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EWS.Domain.Data
{
    public abstract class BaseEnumerableQuery<T>
    {
        public IDictionary<Expression<Func<T, object>>, OrderByDirection> OrderBy { get; set; }
    }
}