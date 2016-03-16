using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EWS.Domain.Data;

namespace EWS.Web.Logic.Infrastructure
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly ILifetimeScope _lifeTimeScope;

        public QueryProcessor(ILifetimeScope lifeTimeScope)
        {
            _lifeTimeScope = lifeTimeScope;
        }

        public TResult Execute<TResult>(IQueryDefinition<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _lifeTimeScope.Resolve(handlerType);
            return handler.Handle((dynamic)query);
            throw new Exception();
        }
    }
}