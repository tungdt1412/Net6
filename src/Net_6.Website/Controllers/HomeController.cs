using Microsoft.AspNetCore.Mvc;

namespace Net_6.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
