﻿using Microsoft.AspNetCore.Mvc;

namespace DangersInfoApp.Controllers
{
    public class HomeController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }
    }
}
