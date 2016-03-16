using Spectrum.SharedKernel.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWS.Domain.DomainServices
{
    public interface ICurrentUserFactory
    {
        SecurityUser GetCurrentUser();
    }
}
