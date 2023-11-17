using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Reflection;
using UniversityApp2.Gateway;
using UniversityApp2.Models;

namespace UniversityApp2.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public List<Student> GetStudents()
        {
            return studentGateway.GetStudents();
        }

        internal dynamic GetDepartments()
        {
            throw new NotImplementedException();
        }
    }
}


