using Microsoft.AspNetCore.Mvc;
using Net_6.Logic.Queries.Interface;
using Net_6.Logic.Shared.Models;

namespace Net_6.Website.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorQueries authorQueries;

        public AuthorController(IAuthorQueries authorQueries)
        {
            this.authorQueries = authorQueries;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int Id)
        {
            var model = new AuthorDetailModel();
            if(Id > 0)
            {
                model = authorQueries.GetDetail(Id);
            }
            
            return View(model);
        }
    }
}
