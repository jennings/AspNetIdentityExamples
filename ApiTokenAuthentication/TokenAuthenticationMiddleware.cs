using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ApiTokenAuthentication.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace ApiTokenAuthentication
{
    public class TokenAuthenticationMiddleware
    {
        readonly AppFunc _next;

        /// <summary>
        /// This constructor is required by OWIN.
        /// </summary>
        /// <param name="next">The next middleware to execute after this one.</param>
        public TokenAuthenticationMiddleware(AppFunc next)
        {
            _next = next;
        }

        /// <summary>
        /// Implements our authorization setup.
        /// </summary>
        /// <param name="environment"></param>
        /// <returns>The result of the next middleware.</returns>
        public async Task Invoke(IDictionary<string, object> environment)
        {
            // Create an OWIN context
            var context = new OwinContext(environment);

            // Our authentication scheme is that the client must send a token like this:
            //
            //     Authorization: Bearer <token>
            //

            // Pull the Authorization header out of the request
            var authorizationHeader = context.Request.Headers["Authorization"];
            if (authorizationHeader != null)
            {
                var headerParts = authorizationHeader.Split(new[] { ' ' }, 2);
                if (headerParts[0] == "Bearer" && headerParts.Length == 2)
                {
                    var token = headerParts[1];

                    // Since we decided to use ASP.NET identity (see: Startup.cs),
                    // we should use the UserManager to figure out who's calling us.
                    var userManager = context.GetUserManager<MyUserManager>();

                    // Find the user that this token represents
                    var user = userManager.Users.SingleOrDefault(u => u.Token == token);
                    if (user != null)
                    {
                        // Cool! We found the user! Sign them in.

                        bool USE_ASPNET_IDENTITY = true;

                        ClaimsIdentity identity;
                        if (USE_ASPNET_IDENTITY)
                        {
                            // If we're using ASP.NET Identity for other things, it can
                            // create ClaimsIdentity objects for us
                            identity = await userManager.CreateIdentityAsync(user, AuthenticationTypes.TokenAuthentication);
                        }
                        else
                        {
                            // If we're not using ASP.NET Identity, we'll have to create the identity
                            // ourselves. I'm assuming we want a ClaimsIdentity.
                            identity = CreateClaimsIdentityWithoutAspNetIdentity(user, AuthenticationTypes.TokenAuthentication);
                        }

                        // When we use cookie authentication, the SignIn(identity) method
                        // eventually sets the Request.User to a principal for us.
                        //
                        // See: Microsoft.Owin.Security.Infrastructure.SecurityHelper.AddUserIdentity(identity),
                        //      which is called by AuthenticationHandler
                        //
                        // Since we're implementing our own middleware, we have to set Request.User ourselves
                        // so other things, like Web API and SignalR, can find it.
                        var principal = new ClaimsPrincipal(identity);
                        context.Request.User = principal;
                    }
                }
            }

            await _next(environment);
        }

        ClaimsIdentity CreateClaimsIdentityWithoutAspNetIdentity(IdentityUser user, string authenticationType)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            return new ClaimsIdentity(claims, authenticationType);
        }
    }
}