using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using CookieAuthentication.Models;
using Microsoft.AspNet.Identity;

namespace CookieAuthentication
{
    public class MyUserManager : UserManager<IdentityUser, int>
    {
        public MyUserManager(IUserStore<IdentityUser, int> store)
            : base(store)
        {
        }

        public static MyUserManager Create()
        {
            var userStore = new MyUserStore();
            var userManager = new MyUserManager(userStore);

            // Use bcrypt to hash passwords
            userManager.PasswordHasher = new MyPasswordHasher();

            return userManager;
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(IdentityUser user, string authenticationType)
        {
            return base.CreateIdentityAsync(user, authenticationType);
        }
    }
}