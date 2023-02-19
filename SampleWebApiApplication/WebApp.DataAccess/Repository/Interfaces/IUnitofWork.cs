namespace WebApp.DataAccess.Repository
{
    public interface IUnitofWork
    {
        IDepartmentRepository Departments { get; }
        IStudentRepository Students { get; }
        void Save();
    }
}