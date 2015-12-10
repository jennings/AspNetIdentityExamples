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
            // Allow the OAuth pipeline to authenticate requests
            config.Filters.Add(new HostAuthenticationFilter(AuthenticationTypes.TokenAuthentication));
            app.UseWebApi(config);
        }

        void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);
            app.Use<TokenAuthenticationMiddleware>();
        }
    }
}