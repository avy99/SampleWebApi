﻿using WebApp.DataAccess.Data;
using WebApp.Models.Models;

namespace WebApp.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Student student)
        {
            _db.Update(student);
        }
    }
}