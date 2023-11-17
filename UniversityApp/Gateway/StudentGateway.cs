//using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Bibliography;
using Humanizer;
using System.Data.SqlClient;
using UniversityApp.Models;
using Department = UniversityApp.Models.Department;
//using Department = DocumentFormat.OpenXml.Bibliography.Department;

namespace UniversityApp.Gateway
{
    public class StudentGateway
    {
        public List<Student> GetStudents()
        {
            SqlConnection con = new SqlConnection("Data Source= DESKTOP-ND72EMQ\\SQLEXPRESS;Initial Catalog=University_DB;Integrated Security=true;");
            string query = "SELECT * FROM vStudentInfo";
           
               // SELECT* FROM Uni_Student_Table
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Student> students = new List<Student>();
            while (reader.Read()) 
            {
                Student student = new Student();
                student.StudentName = reader["StudentName"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.Email = reader["Email"].ToString();
                student.Address = reader["Address"].ToString();
                student.DepartmentName = reader["DepartmentName"].ToString();
                students.Add(student);
            }
            con.Close();
            return students;
        
        }
        public List<Department> GetDepartments()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ND72EMQ\SQLEXPRESS;Initial Catalog=University_DB;Integrated Security=true;");
            string query = "SELECT*FROM Department_Table";
            //select * from Uni_Student_Table INNER JOIN Department_Table On Uni_Student_Table.DepartmentId=Department_Table.Id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.Id = (int)reader["Id"];
               // department.DepartmentName = reader["DepartmentName"].ToString();//TM
                department.ShortName = reader["ShortName"].ToString();
                departments.Add(department);
            }
            con.Close();
            return departments;
        }
    }
}
/// SELECT* FROM Uni_Student_Table INNER JOIN Department_Table ON Uni_Student_Table.DepartmentId = Department_Table.Id