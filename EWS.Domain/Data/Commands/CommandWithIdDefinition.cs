using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWS.Domain.Data.Commands
{
    public class CommandWithIdDefinition<T> : BaseEntityCommand, ICommandDefinition
    {
        public T Id { get; set; }
    }
}
