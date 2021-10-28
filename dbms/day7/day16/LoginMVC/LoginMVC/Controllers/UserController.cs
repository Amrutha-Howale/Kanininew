using LoginMVC.Models;
using LoginMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Controllers
{
    public class UserController : Controller
    {
        public object Session { get; private set; }

        /* private readonly IRepo<User> _repo;

public UserController(IRepo<User> repo)
{
_repo = repo;
}*/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Authorize(User user)
        {
            HttpContext context;
            using (UserContext db = new UserContext())
            {
                try
                {
                    var userDetails = db.users.Where(x => x.Id == user.Id && x.Password == user.Password).FirstOrDefault();
                if(userDetails==null)
                {
                    user.LoginErrorMessage = "Invalid username or password";
                    return View("Index", user);
                }
                else
                {
                    //Session["userId"] = user.Id;
                    return RedirectToAction("Index", "Authorize");
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return View();
        }
    }
}
