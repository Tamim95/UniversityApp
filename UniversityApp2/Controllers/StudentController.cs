using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityApp2.Manager;
using UniversityApp2.Models;

namespace UniversityApp2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SaveStudent()
        {
            StudentManager studentManager = new StudentManager();
            ViewBag.Department = studentManager.GetDepartments();
            ViewBag.Students = studentManager.GetStudents();
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            StudentManager studentManager = new StudentManager();
            string mgs = "";
            if (ModelState.IsValid)
            {

            
            SqlConnection con = new SqlConnection("Data Source= DESKTOP-ND72EMQ\\SQLEXPRESS;Initial Catalog=University_DB;Integrated Security=true;");
            con.Open();
            string query = "INSERT INTO Student_Table(StudentName,RegNo,Email,Address,DepartmentName) VALUES('"+student.StudentName+ "','"+student.RegNo+"','"+student.Email+"','"+student.Address+"','"+student.DepartmentName+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            int countRow= cmd.ExecuteNonQuery();
            if (countRow > 0)
            {
                mgs= "Save successfully.";
            }
            else
            {
                mgs= "Save Failed";
            }
            }
            ViewBag.Department = studentManager.GetDepartments();
            ViewBag.Students = studentManager.GetStudents();
            ViewBag.Message = mgs;
            return View();


        }
        public List<string> GetDepartments()
        {
            return new List<string>() { "CSE", "EEE", "ENG" };
        }

        public ActionResult GetAll()
        {
            // ViewBag.Student = Students();
            return View(Students());
        }
        public List<Student> Students()
        {
            return new List<Student> {
               new Student {StudentName="Ali",RegNo="12345",Email="ali@gmail.com",Address="Kolkata",DepartmentName="Physics" },
                new Student {StudentName="Salam",RegNo="12346",Email="salam@gmail.com",Address="Kolkata",DepartmentName="Physics" },
                new Student {StudentName="Kalam",RegNo="12347",Email="kalam@gmail.com",Address="Kolkata",DepartmentName="Physics" }
            };
        }
        
    }
}
