using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Week11Day5.Models;
using Week11Day5.Services;

namespace Week11Day5.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents();

            return View(students);
        }

        [HttpPost]
        public ActionResult GetByName(string studentName)
        {
            List<Student> students;

            if (!string.IsNullOrEmpty(studentName))
                students = _studentService.GetStudentsByName(studentName);
            else
                students = _studentService.GetAllStudents();
            
            //return View("Index", students);
            return View(nameof(Index), students);
        }
    }
}
