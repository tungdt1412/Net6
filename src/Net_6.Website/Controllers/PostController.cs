﻿using Microsoft.AspNetCore.Mvc;

namespace Net_6.Website.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
