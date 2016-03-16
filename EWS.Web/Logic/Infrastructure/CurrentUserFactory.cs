using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EWS.Domain.DomainServices;

namespace EWS.Web.Logic.Infrastructure
{
    public class CurrentUserFactory : ICurrentUserFactory
    {
        public CurrentUserFactory()
        {

        }

        public Spectrum.SharedKernel.Authentication.SecurityUser GetCurrentUser()
        {
            return UserSession.GetUser();
        }
    }
}