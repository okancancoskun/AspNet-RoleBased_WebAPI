using Project.API.Business.Interfaces;
using Project.API.DataAccess.Interfaces;
using Project.API.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.Concrete
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDal<TEntity> _repository;
        public GenericService(IGenericDal<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.GetAllByFilter(filter);
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.GetByFilter(filter);
        }

        public async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }
    }
}
