using EmployeeFrontEnd.Models;
using EmployeeFrontEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeFrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginServices _LoginService;

        public LoginController(LoginServices service)
        {
            _LoginService = service;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDTO employeeDTO)
        {
            try
            {
                EmployeeDTO employee = _LoginService.Register(employeeDTO);
                if (employee != null)
                {
                    TempData["token"] = employee.jwtToken;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Not Registered";
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(EmployeeDTO empDTO)
        {
            try
            {
                EmployeeDTO employee = _LoginService.Login(empDTO);
                if (employee != null)
                {
                    TempData["token"] = employee.jwtToken;
                    return RedirectToAction("EmployeeAdd");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public ActionResult EmployeeAdd()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeAdd(EmployeeAddDTO empDTO)
        {
            try
            {
                EmployeeAddDTO emp = _LoginService.EmployeeAdd(empDTO);
                if (emp != null)
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Not Employee";
            return View();
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
