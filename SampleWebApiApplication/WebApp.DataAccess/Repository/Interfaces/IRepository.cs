using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApp.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id, string includeProperties = null);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, string includeProperties = null);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);

        Task Add(T entity);
        Task Remove(T entity);
        Task RemoveAt(int id);
        Task RemoveRange(IEnumerable<T> entity);
    }
}