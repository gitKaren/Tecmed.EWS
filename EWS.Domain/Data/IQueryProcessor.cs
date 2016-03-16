using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWS.Domain.Data
{
    public interface IQueryProcessor
    {
        TResult Execute<TResult>(IQueryDefinition<TResult> query);
    }
}
