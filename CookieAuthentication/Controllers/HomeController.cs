using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CookieAuthentication.Views.Home;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CookieAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Authenticated()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInViewModel model)
        {
            // Get the OWIN context and UserManager
            var owinContext = Request.GetOwinContext();
            var userManager = owinContext.GetUserManager<MyUserManager>();

            // Ask our UserManager to find our user
            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                // If we found the user, verify the password
                if (await userManager.CheckPasswordAsync(user, model.Password))
                {
                    // Cool! Create an identity and set it so our [Authorize] attributes work.
                    var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    owinContext.Authentication.SignIn(identity);

                    // Now go away
                    return RedirectToAction("Authenticated");
                }
            }

            ModelState.AddModelError("invalid_password", "Unknown username or password");
            return View(model);
        }

        // Usually this is POST, but whatever
        [HttpGet]
        public ActionResult SignOut()
        {
            var owinContext = Request.GetOwinContext();
            owinContext.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index");
        }
    }
}