using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Models
{
    public class Student
    {
        [Key] public int StudentId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        [Required] public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")] public Department Department { get; set; }
    }
}