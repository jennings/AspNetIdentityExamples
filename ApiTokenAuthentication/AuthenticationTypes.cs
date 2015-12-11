using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTokenAuthentication
{
    public static class AuthenticationTypes
    {
        /// <summary>
        /// Since we're implementing our own authentication scheme, we need a unique
        /// string to identify it. We could configure ASP.NET Identity to provide both
        /// TokenAuthentication using our middleware and, say, cookie authentication
        /// using the Microsoft.Owin.Security.Cookies infrastructure.
        /// </summary>
        public const string TokenAuthentication = "TokenAuthentication";
    }
}