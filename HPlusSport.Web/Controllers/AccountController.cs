using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using HPlusSport.Web.Classes;
using HPlusSport.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace HPlusSport.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            using (var db = new ShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null || PasswordHelper.VerifyPassword(
                        password,
                        new HashInformation
                        {
                            Hash = user.Hash,
                            Salt = user.Salt
                        }
                    ) == false)
                {
                    ViewBag.Message = "User name or password invalid";
                    return View();
                }

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

                //var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie,
                    ClaimTypes.Email, "");

                AuthenticationManager.SignIn(identity);

                return RedirectToAction("Index", "Shop");
            }
        }

        public ActionResult Logout()
        {
            return View();
        }

        // POST: Account/Logout
        [HttpPost]
        [ActionName("Logout")]
        public ActionResult LogoutPost()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}