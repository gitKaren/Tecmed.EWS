using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EWS.Domain.Data;

namespace EWS.Web.Logic.Infrastructure
{
    public sealed class CommandProcessor : ICommandProcessor
    {
        private readonly ILifetimeScope _lifeTimeScope;

        public CommandProcessor(ILifetimeScope lifeTimeScope)
        {
            _lifeTimeScope = lifeTimeScope;
        }

        public void Execute(ICommandDefinition command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _lifeTimeScope.Resolve(handlerType);
            handler.Handle((dynamic)command);
        }
    }
}