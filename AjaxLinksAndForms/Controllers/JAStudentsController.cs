using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxLinksAndForms.Data;
using AjaxLinksAndForms.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxLinksAndForms.Controllers
{
    [Produces("application/json")]
    public class JAStudentsController : Controller
    {

        SchoolDbContext schoolDbContext;
        public JAStudentsController(SchoolDbContext _schoolDbContext)
        {
            schoolDbContext = _schoolDbContext;     
        }
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var students = schoolDbContext.Students;
            return students;
        }

        [HttpGet]
        public Student GetStudentById(int id)
        {
            var student = schoolDbContext.Students.Find(id);
            return student;
        }


        [HttpPost]
        public string UpdateStudent(Student student)
        {
            if (student.StudentId==0)
            {
                schoolDbContext.Add<Student>(student);
            }
            else
            {
                schoolDbContext.Update<Student>(student);
            }
            schoolDbContext.SaveChanges();
            return "Operation Successful!";
        }

        [HttpGet]
        public string DeleteStudent(int id)
        {
            var student = schoolDbContext.Students.Find(id);
            schoolDbContext.Remove<Student>(student);
            schoolDbContext.SaveChanges();
            return "Deleted Successfully!";
        }

    }
}