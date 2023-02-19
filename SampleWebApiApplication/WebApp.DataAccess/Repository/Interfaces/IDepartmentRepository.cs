using System.Threading.Tasks;
using WebApp.Models.Models;

namespace WebApp.DataAccess.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task Update(Department department);
    }
}