using LoginTwoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTwoApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        public IActionResult UserLogin()
        {
            _logger.LogInformation("Login hit" + DateTime.Now.ToString());
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(User user)
        {
            if (ModelState.IsValid)
            {
                
                TempData["username"] = user.Username;
                TempData["role"] = user.Role;
                if (user.Username.Length == 3 && user.Password.Length == 4)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                    _logger.LogError("Invalid Login attempt" + DateTime.Now);
            }
            return View();
        }
        
    }
}
