using EmployeeDetailsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsMVC.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>();
        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employees.Add(employee);
            return RedirectToAction("Index");
        }
    }
}
