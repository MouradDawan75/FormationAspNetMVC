using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04_Routage.Models;

namespace _04_Routage.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>
        {
            new Student{Id = 1, Name = "Jean"},
            new Student{Id = 2, Name = "Marie"},
            new Student{Id = 3, Name = "Romain"},
        };

        [HttpGet]
        //[Route("students")]
        [Route("")]
        public ActionResult GetAllStudents()
        {
            return View(students);
        }

        [HttpGet]
        //[Route("students/{id}")]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var student = students.SingleOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpGet]
        [Route("{id}/courses")]
        public ActionResult GetStudentCourses(int id)
        {
            List<string> CourseList = new List<string>();
            if(id == 1)
            {
                CourseList = new List<string> { "ASP.Net", "C#" };
            }else if(id == 2)
            {
                CourseList = new List<string> { "Java", "Spring" };
            }
            else
            {
                CourseList = new List<string> { "JavaScript", "Angular" };
            }

            ViewBag.Courses = CourseList;
            return View();
        }

        //~: permet de faire un override du route prefix : ignorer le routeprefix
        [HttpGet]
        [Route("~/teachers")]
        public ActionResult GetTeachers()
        {
            var teachers = new List<Teacher>
            {
                new Teacher {Id = 1, Name = "Dawan"},
                new Teacher {Id = 2, Name = "Jehann"}
            };

            return View(teachers);
        }
    }
}