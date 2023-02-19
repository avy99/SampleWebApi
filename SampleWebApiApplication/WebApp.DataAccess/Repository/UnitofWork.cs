using System;
using WebApp.DataAccess.Data;

namespace WebApp.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Departments = new DepartmentRepository(_db);
            Students = new StudentRepository(_db);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public IDepartmentRepository Departments { get; }
        public IStudentRepository Students { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}