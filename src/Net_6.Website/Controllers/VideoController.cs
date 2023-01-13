using Microsoft.AspNetCore.Mvc;

namespace Net_6.Website.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
