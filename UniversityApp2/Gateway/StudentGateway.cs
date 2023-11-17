using System.Data.SqlClient;
using UniversityApp2.Models;

namespace UniversityApp2.Gateway
{
    public class StudentGateway
    {
        public List<Student> GetStudents()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ND72EMQ\SQLEXPRESS;Initial Catalog=University_DB;Integrated Security=true;");
            string query = "SELECT*FROM Student_Table";

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
    }
}
