using DocumentFormat.OpenXml.Bibliography;
using UniversityApp.Gateway;
using UniversityApp.Models;
using Department = UniversityApp.Models.Department;
//using Department = UniversityApp.Models.Department;

namespace UniversityApp.Manager
{
    public class StudentManager
    {
       
            StudentGateway studentGateway = new StudentGateway();

            public List<Student> GetStudents()
            {
                return studentGateway.GetStudents();
            }

        public List<Department> GetDepartments()
        {
            return studentGateway.GetDepartments();
        }
    }
    }

