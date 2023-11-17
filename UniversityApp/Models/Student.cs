using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Student
    {
        [Required (ErrorMessage = "Please enter your name "),MaxLength(30),MinLength(3)]
        [Display (Name = "Student Name")]
        public string? StudentName { get; set; }
        [Required(ErrorMessage ="Enter your Registration Number"),MaxLength(20)]
        [Display(Name = "Registration Number")]
        public string? RegNo { get; set; }
        [Required(ErrorMessage ="Enter proper mail address")]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required]
        [Display(Name ="Department Name")]
        public string? DepartmentName { get; set; }
    }
}
