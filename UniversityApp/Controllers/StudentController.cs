using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using UniversityApp.Manager;
using UniversityApp.Models;


namespace UniversityApp.Controllers
{
    public class StudentController : Controller
    {
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
                string query ="INSERT INTO Uni_Student_Table(StudentName,RegNo,Email,Address,DepartmentId) VALUES('"+student.StudentName+"','"+student.RegNo+"','"+student.Email+"','"+student.Address+"','"+student.DepartmentName+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                int countRow = cmd.ExecuteNonQuery();
                if (countRow > 0)
                {
                    mgs = "Save successfully.";
                }
                else
                {
                    mgs = "Save Failed";
                }
            }
            ViewBag.Department = studentManager.GetDepartments();
            ViewBag.Students = studentManager.GetStudents();
            ViewBag.Message = mgs;
            return View();


        }
        public ActionResult GetAll()
        {
            // ViewBag.Student = Students();
            return View(Students());
        }


        public List <string> GetDepartments()
        {
            return new List<string>(){ "CSE","EEE","ENG"};
        }

       

        /*
        //This is string SaveStudent method .I used it for save data from browser.
        public string SaveStudent(Student student)
        {
            //Connectiong Database using SqlConnection class
            SqlConnection con = new SqlConnection("Data Source= DESKTOP-ND72EMQ\\SQLEXPRESS;Initial Catalog=University_DB;Integrated Security=true;");
            con.Open();
            string query = "INSERT INTO Student_Table (StudentName,RegNo,Email,Address,DepartmentName) VALUES('"+student.StudentName+"','"+student.RegNo+ "','"+student.Email +"','"+student.Address+"','" +student.DepartmentName +"')";
            SqlCommand cmd = new SqlCommand(query, con);
            int rowCount = cmd.ExecuteNonQuery();
            
            if(rowCount>0)
            {
                return "Save Data successfully";
            }
            return "Save failed";
        }
        */

        // testing on Browser: /Student/SaveStudent?StudentName=Tamim&RegNo=123&Email=tamim@gmail.com&Address=Dhaka&DepartmentName=CSE

        public ActionResult Index()
        {
            ViewBag.Message = "Hello Batch 54";
            Student student = new Student();
            student.StudentName = "Noman";
            student.RegNo = "2011";
            student.Email = "noman@mail.com";
            student.Address = "Maymansingh";
            ViewBag.Student = student;

            return View();
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
