using FirstMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApplication.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            /*int[] score = { 100, 89, 97 };
            ViewBag.Name = "Tim";
            ViewData["Username"] = "userTim";
            ViewBag.Scores = score;
            ViewData["Scores"] = score;*/
            Student student = new Student();
            student.Id = 101;
            student.Name = "Tim";
            student.Age = 21;
            ViewBag.Student = student;
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
