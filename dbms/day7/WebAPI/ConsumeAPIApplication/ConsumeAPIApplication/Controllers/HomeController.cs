using ConsumeAPIApplication.Models;
using ConsumeAPIApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeAPIApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserService _userService { get; }

        public HomeController(ILogger<HomeController> logger,UserService service)
        {
            _logger = logger;
            _userService = service;
        }

        public IActionResult Index()
        {
            if (TempData["token"] != null)
            {
              string weatherDate= _userService.CallWeather( TempData.Peek("token").ToString());
                ViewBag.Weather = weatherDate;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
