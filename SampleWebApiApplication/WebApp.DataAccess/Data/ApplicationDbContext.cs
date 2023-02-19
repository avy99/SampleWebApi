using Microsoft.EntityFrameworkCore;
using WebApp.Models.Models;

namespace WebApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //        .HasOne(e => e.Name)
        //        .WithMany()
        //        .HasForeignKey(e => e.DepartmentId);
        //}
    }
}