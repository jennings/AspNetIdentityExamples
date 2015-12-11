using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Owin;

namespace ApiTokenAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // Tell Web API to use the OAuth pipeline to authenticate requests
            config.Filters.Add(new HostAuthenticationFilter(AuthenticationTypes.TokenAuthentication));

            app.UseWebApi(config);
        }

        void ConfigureAuth(IAppBuilder app)
        {
            // Stick our UserManager in the OWIN environment
            //
            // Actually, we don't even really need to use ASP.NET Identity for this.
            // Since we're implementing our own middleware, we don't have to use the UserManager
            // to look up the identity of the user calling us.
            //
            // But, it's possible our app serves both token authentication (API) and, say, cookie
            // authentication (website), so we can use the same ASP.NET Identity infrastructure
            // for both.
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);

            // Tell OWIN to use our middleware, which happens to implement token authentication
            app.Use<TokenAuthenticationMiddleware>();
        }
    }
}