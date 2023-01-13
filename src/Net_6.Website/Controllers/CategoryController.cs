using Microsoft.AspNetCore.Mvc;

namespace Net_6.Website.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
