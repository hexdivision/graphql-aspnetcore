using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PathWays.Data.Repositories.Base
{
    public interface IRepository<T>
        where T : class
    {
        DbSet<T> DbSet { get; set; }

        void Attach(T obj);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> where);

        Task<ICollection<T>> GetAllAsync();

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        Task<T> GetNoTrackingByIdAsync(Expression<Func<T, bool>> where);

        Task<T> InsertAsync(T obj);

        void Update(T obj);
    }
}