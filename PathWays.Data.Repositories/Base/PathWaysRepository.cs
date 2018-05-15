using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PathWays.Data.Model;

namespace PathWays.Data.Repositories.Base
{
    /// <summary>
    /// Base repo for repositories
    /// </summary>
    /// <typeparam name="T">Class type</typeparam>
    public class PathWaysRepository<T> : IRepository<T>
        where T : class
    {
        private readonly PathWaysContext context;

        protected PathWaysRepository(PathWaysContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public DbSet<T> DbSet { get; set; }

        protected List<string> TrackedProperties { get; set; }

        protected PathWaysContext Context => context;

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.Where(where).ToListAsync();
        }

        public async Task<T> InsertAsync(T obj)
        {
            var inserted = await DbSet.AddAsync(obj);
            return inserted.Entity;
        }

        public void Update(T obj)
        {
            DbSet.Update(obj);
        }

        public void Attach(T obj)
        {
            DbSet.Local.Remove(obj);
            DbSet.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        public async Task<T> GetNoTrackingByIdAsync(Expression<Func<T, bool>> where)
        {
            return await DbSet.AsNoTracking().SingleOrDefaultAsync(where);
        }
    }
}
