using Microsoft.EntityFrameworkCore;
using Project.API.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.API.DataAccess.Interfaces;
using Project.API.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task Add(TEntity entity)
        {
            using var context = new ApiContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            using var context = new ApiContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ApiContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ApiContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> FindById(int id)
        {
            using var context = new ApiContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            using var context = new ApiContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            using var context = new ApiContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
