using Net_6.Website.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;
using Net_6.Database.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Net_6.Ultils.Extensions;
using Net_6.Logic.Queries.Interface;
using Net_6.Logic.Shared.Models;
using Net_6.Common.Shared.Model;
using Net_6.Ultils.Global;
using Net_6.Logic.Commands.Request;

namespace Net_6.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserQueries userQueries;

        public UserController(IMediator mediator, IUserQueries userQueries)
        {
            this.mediator = mediator;
            this.userQueries = userQueries;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var model = new List<UserSummaryModel>();
            model = userQueries.GetAll();
            return PartialView();
        }

        public IActionResult Detail(string? userName)
        {
            var model = new UserDetailModel();

            if (!string.IsNullOrEmpty(userName))
            {
                model = userQueries.GetDetail(userName);
            }
            return View(model);
        }

        public async Task<ActionResult> SaveChange(UserDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetBaseFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<User>();

                if (!userQueries.IsExistUserName(model.DetailUserName ?? string.Empty))
                {
                    var createCommand = model.ToCreateCommand();
                    commandResult = await mediator.Send(createCommand);
                }
                else
                {
                    var updateCommand = model.ToUpdateCommand();
                    commandResult = await mediator.Send(updateCommand);
                }

                if (commandResult.Success)
                {
                    return Json(new { success = false, message = AppGlobal.DefaultSuccessMessage, data = commandResult.Data });
                }
                else
                {
                    ModelState.AddModelError("", commandResult.Messages);
                    return Json(new { success = false, message = commandResult.Messages });
                }
            }
            else
            {
                return Json(new { success = false, message = ModelState.GetError() });
            }
        }

        public async Task<ActionResult> Delete(string userName)
        {
            var command = new DeleteUser()
            {
                DeleteUserName = userName,
                RequestId = HttpContext.Connection?.Id,
                IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                UserName =HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == "UserName")?.Value
            };
            var result = await mediator.Send(command);
            return Json(new { success = result.Success, message = result.Messages });
        }

        [HttpGet]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ResetPasswordConfirm(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetBaseFromContext(HttpContext);
                var commandResult = new BaseCommandResult();
                var resetPasswordCommand = model.ToResetPasswordCommand();
                commandResult = await mediator.Send(resetPasswordCommand);

                return Json(new { success = commandResult.Success, message = ModelState.GetError() });
            }
            else
            {
                return Json(new { success = false, message = ModelState.GetError() });
            }
            return View(model);
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
                model.ErrorMessage = ModelState.GetError();
                return RedirectToAction("AdminLogin", model);
            }
        }
    }
}
