using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiTokenAuthentication.Models;
using Microsoft.AspNet.Identity;

namespace ApiTokenAuthentication
{
    public partial class MyUserStore : IUserStore<IdentityUser, int>
        , IQueryableUserStore<IdentityUser, int>
    {
        static HashSet<IdentityUser> USERS = new HashSet<IdentityUser>
        {
            new IdentityUser{ Id = 1, Token="A", UserName = "Alpha" },
            new IdentityUser{ Id = 2, Token="B", UserName = "Bravo" },
            new IdentityUser{ Id = 3, Token="C", UserName = "Charlie" },
            new IdentityUser{ Id = 4, Token="D", UserName = "Delta" },
            new IdentityUser{ Id = 5, Token="E", UserName = "Echo" },
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

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(USERS.SingleOrDefault(u => u.UserName == userName));
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
    }
}