using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ApiTokenAuthentication
{
    using System.Security.Claims;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class TokenAuthenticationMiddleware
    {
        readonly AppFunc _next;

        public TokenAuthenticationMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
            var authorizationHeader = context.Request.Headers["Authorization"];
            if (authorizationHeader != null)
            {
                var headerParts = authorizationHeader.Split(new[] { ' ' }, 2);
                if (headerParts[0] == "Bearer" && headerParts.Length == 2)
                {
                    var token = headerParts[1];
                    var userManager = context.GetUserManager<MyUserManager>();
                    var user = userManager.Users.SingleOrDefault(u => u.Token == token);
                    if (user != null)
                    {
                        var identity = await userManager.CreateIdentityAsync(user, AuthenticationTypes.TokenAuthentication);
                        var principal = new ClaimsPrincipal(identity);
                        context.Request.User = principal;
                        context.Authentication.SignIn(identity);
                    }
                }
            }

            await _next(environment);
        }
    }
}