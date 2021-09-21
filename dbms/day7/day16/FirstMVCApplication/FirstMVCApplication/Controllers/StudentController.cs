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
        static List<Student> students = new List<Student>();
        public IActionResult Index()
        {
            /*int[] score = { 100, 89, 97 };
            ViewBag.Name = "Tim";
            ViewData["Username"] = "userTim";
            ViewBag.Scores = score;
            ViewData["Scores"] = score;*/
            /*Student student = new Student();
            student.Id = 101;
            student.Name = "Tim";
            student.Age = 21;
            ViewBag.Student = student;*/
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            students.Add(student);
            return RedirectToAction("Index");
        }
    }
}
