
using Microsoft.EntityFrameworkCore;
using Shopping.Data.Contexts;
using Shopping.Data.IRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
#pragma warning disable
        internal MYDBContext dbcontext;
        internal DbSet<T> dbset;
        public GenericRepository(MYDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
            this.dbset = dbcontext.Set<T>();
        }


        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbset.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = dbset.Update(entity);
            return entry.Entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbset.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var entity = await dbset.FirstOrDefaultAsync(expression);

            if (entity is null) return false;

            dbset.Remove(entity);
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? dbset : dbset.Where(expression);

        }
    }
}
