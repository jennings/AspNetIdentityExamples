using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace CookieAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        void ConfigureAuth(IAppBuilder app)
        {
            // Stick our UserManager in the OWIN environment
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                // ASP.NET Identity can provide several methods of authentication in the same app.
                // This string is used to identify this configuration of "cookie authentication".
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                // Hopefully you use HTTPS. For this demo, oh well.
                CookieSecure = CookieSecureOption.SameAsRequest,

                // The provider lets you add additional logic during authentication.
                // Since we're doing everything out-of-the-box, the default is fine.
                Provider = new CookieAuthenticationProvider(),
            });
        }
    }
}