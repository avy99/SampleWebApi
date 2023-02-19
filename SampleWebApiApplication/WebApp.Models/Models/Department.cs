using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Models
{
    public class Department
    {
        [Key] public int DepatmentId { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
    }
}