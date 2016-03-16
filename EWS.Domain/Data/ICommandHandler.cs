using System.Collections.Generic;

namespace EWS.Domain.Data
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommandDefinition
    {
        void Handle(TCommand command);
    }
}