﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Specs()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
