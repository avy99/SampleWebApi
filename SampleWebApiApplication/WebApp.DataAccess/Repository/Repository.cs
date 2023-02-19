using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;

namespace WebApp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> dbSet;
        protected ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task RemoveAt(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null) dbSet.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public async Task<T> Get(int id, string includeProperties = null)
        {
            var model = await dbSet.FindAsync(id);
            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    _db.Entry(model).Reference(includeProp).Load();

            return model;
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (orderBy != null) query = (IQueryable<T>) orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            return await query.FirstOrDefaultAsync();
        }
    }
}