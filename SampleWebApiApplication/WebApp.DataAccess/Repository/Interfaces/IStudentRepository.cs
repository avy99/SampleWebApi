using WebApp.Models.Models;

namespace WebApp.DataAccess.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);
    }
}