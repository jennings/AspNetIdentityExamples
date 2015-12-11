using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CookieAuthentication.Models;
using Microsoft.AspNet.Identity;

namespace CookieAuthentication
{
    public partial class MyUserStore : IUserStore<IdentityUser, int>
        , IQueryableUserStore<IdentityUser, int>
    {
        // We find users by name when signing in
        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(USERS.SingleOrDefault(u => userName.Equals(u.UserName, StringComparison.InvariantCultureIgnoreCase)));
        }


        #region Other Boilerplate

        static HashSet<IdentityUser> USERS = new HashSet<IdentityUser>
        {
            new IdentityUser{ Id = 1, UserName = "Alpha", PasswordHash = "$2a$04$OFeBgp2Oe7aHOoENpgBqB.D1cUto3ike8JnozdatvP8iSYjUhlwMm" },
            new IdentityUser{ Id = 2, UserName = "Bravo", PasswordHash = "$2a$04$VTocahmg2UMhJ71pQQukW.YYFHmcB1WaBHG1CZL1uzGMvjq0Esosu" },
            new IdentityUser{ Id = 3, UserName = "Charlie", PasswordHash = "$2a$04$n5WujIZysIWV.J6v/d4HS.Yo7y7q6BW0gw6lmsIyJN/1W5f7r4F2C" },
            new IdentityUser{ Id = 4, UserName = "Delta", PasswordHash = "$2a$04$qzIph9OKdx.jMO5YCmgM1edSZ67Xsn3XAh5StQPePUW7vGHspExLO" },
            new IdentityUser{ Id = 5, UserName = "Echo", PasswordHash = "$2a$04$VC0s/HqewhYFh5HeN2eUG.RDq4A5erECd98//nJdwSuhqGagS1gDS" },
        };

        public Task CreateAsync(IdentityUser user)
        {
            if (USERS.Any(u => u.Id == user.Id))
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(new InvalidOperationException());
                return tcs.Task;
            }
            USERS.Add(user);
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            USERS.RemoveWhere(u => u.Id == user.Id);
            return Task.FromResult<object>(null);
        }

        public Task<IdentityUser> FindByIdAsync(int userId)
        {
            return Task.FromResult(USERS.SingleOrDefault(u => u.Id == userId));
        }

        public Task UpdateAsync(IdentityUser user)
        {
            USERS.RemoveWhere(u => u.Id == user.Id);
            USERS.Add(user);
            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            // No implementation
        }

        public IQueryable<IdentityUser> Users
        {
            get { return USERS.AsQueryable(); }
        }

        #endregion
    }
}