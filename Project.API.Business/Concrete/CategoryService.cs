using Project.API.Business.Interfaces;
using Project.API.DataAccess.Interfaces;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Business.Concrete
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        ICategoryDal _repository;
        public CategoryService(ICategoryDal repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
