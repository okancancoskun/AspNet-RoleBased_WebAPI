using Project.API.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindById(int id);
        Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task Update(TEntity entity);
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
    }
}
