using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ApiTokenAuthentication.Models;
using Microsoft.AspNet.Identity;

namespace ApiTokenAuthentication
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
            return userManager;
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(IdentityUser user, string authenticationType)
        {
            return base.CreateIdentityAsync(user, authenticationType);
        }
    }
}