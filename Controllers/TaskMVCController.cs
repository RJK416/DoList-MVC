using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoListMVC.Controllers
{
    public class TaskMVCController : Controller
    {
        // GET: MyAccountController
        public ActionResult Index()
        {
            return View();
        }


        // GET: MyAccountController
        public ActionResult Finished()
        {
            return View();
        }


        // GET: MyAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> CreateAsync()
        {
            var token = await HttpContext.GetTokenAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Retrieve user ID from claims
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            // Pass user ID and token to the view
            ViewBag.UserId = userId;
            ViewBag.AuthToken = token;

            return View();
        }

        // POST: MyAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.TaskId = id;
            return View();
        }

        // POST: MyAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
