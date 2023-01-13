using Net_6.Website.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;
using Net_6.Database.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Net_6.Ultils.Extensions;

namespace Net_6.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
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
        public async Task<ActionResult> AdminLoginSubmit(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = model.ToCommand();
                var result = await mediator.Send(command);

                if (result.Success)
                {
                    var user = result.Data;
                    var claims = new List<Claim>()
                    {
                            new Claim("UserName", user!.UserName),
                            new Claim("AuthorId", user!.AuthorId ?? string.Empty)
                    };

                    var claimIdentities = new List<ClaimsIdentity>()
                    {
                        new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
                    };

                    var claimPrincipal = new ClaimsPrincipal(claimIdentities);
                    await HttpContext.SignInAsync(claimPrincipal);


                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction(model.ReturnUrl);
                    }
                }
                else
                {
                    model.ErrorMessage = model.ErrorMessage ?? string.Empty;
                    return RedirectToAction("AdminLogin", model);
                }
            }
            else
            {
                model.ErrorMessage = ModelState.GetError() ;
                return RedirectToAction("AdminLogin", model);
            }
        }
    }
}
