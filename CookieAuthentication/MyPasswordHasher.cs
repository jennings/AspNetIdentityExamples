using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CookieAuthentication
{
    public class MyPasswordHasher : IPasswordHasher
    {
        // Please, please, PLEASE do not create your own password hash function.
        // ASP.NET Identity includes a default hasher, but if you need to override it,
        // make sure you're using a hash function like Bcrypt or PKDBF2.

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}