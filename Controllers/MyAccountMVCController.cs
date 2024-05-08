using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DoListMVC.Models;
using Microsoft.AspNetCore.Cors;

namespace DoListMVC.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class MyAccountMVCController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("MyAccountMVC/LoginAttempt")]
        public async Task<IActionResult> LoginAttempt(string AccName, string Id)
        {
            // Create claims for the user
            var claims = new List<Claim>
             {
        new Claim(ClaimTypes.Name, AccName),
        new Claim(ClaimTypes.NameIdentifier, Id.ToString()), // Assuming user.Id is the unique identifier
        // Add other claims as needed
        // For example:
        // new Claim(ClaimTypes.Email, user.Email), // If you have user email
             };

            // Create identity
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Create authentication properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Persist the cookie
                ExpiresUtc = DateTimeOffset.UtcNow.AddMonths(1), // Set the expiration time for the cookie
                AllowRefresh = true, // Allow refreshing the authentication session
            };

            // Create the principal
            var principal = new ClaimsPrincipal(claimsIdentity);

            // Sign in the user
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                authProperties);


            return Ok(new { success = true, message = "LoginAttempt method called successfully." });
        }


        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IndexUser(string AccName, string ID)
        {

            return View();
        }

        public ActionResult Created()
        {
            return View();
        }

    }
}
