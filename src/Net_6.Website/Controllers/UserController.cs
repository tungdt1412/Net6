using Net_6.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace Net_6.Website.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin(LoginViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult AdminLoginSubmit(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("AdminLogin", model);
            }
        }
    }
}
