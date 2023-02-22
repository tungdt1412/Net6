using MediatR;
using Microsoft.AspNetCore.Mvc;
using Net_6.Common.Shared.Model;
using Net_6.Database.Entities;
using Net_6.Logic.Commands.Request;
using Net_6.Logic.Queries.Interface;
using Net_6.Logic.Shared.Models;
using Net_6.Ultils.Extensions;
using Net_6.Ultils.Global;
using Net_6.Website.Models;
using System.Security.Claims;

namespace Net_6.Website.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorQueries authorQueries;
        private readonly IMediator mediator;

        public AuthorController(IAuthorQueries authorQueries,
            IMediator mediator)
        {
            this.authorQueries = authorQueries;
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var model = new List<AuthorSummaryModel>();
            model = authorQueries.GetAll();

            return PartialView(model);
        }

        public IActionResult Detail(int Id)
        {
            var model = new AuthorDetailModel();
            if (Id > 0)
            {
                model = authorQueries.GetDetail(Id);
            }

            return View(model);
        }

        public async Task<ActionResult> SaveChange(AuthorDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetBaseFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<Author>();
                if (model.Id == 0)
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

        public async Task<ActionResult> Delete(int Id)
        {
            var command = new DeleteAuthor()
            {
                Id = Id,
                RequestId = HttpContext.Connection?.Id,
                IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
            };

            var result = await mediator.Send(command);

            return Json(new { success = result.Success, message = result.Messages });
        }
    }
}
