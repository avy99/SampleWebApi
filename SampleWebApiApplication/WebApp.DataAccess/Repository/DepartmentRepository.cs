using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.Models.Models;

namespace WebApp.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(Department department)
        {
            var obj = await _db.Departments.FirstOrDefaultAsync(x => x.DepatmentId == department.DepatmentId);
            if (obj != null)
            {
                obj.DepartmentHead = department.DepartmentHead;
                obj.DepartmentName = department.DepartmentName;
                _db.Update(obj);
            }
        }
    }
}