using Project.API.Business.Interfaces;
using Project.API.DataAccess.Interfaces;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Business.Concrete
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductDal _repository;
        public ProductService(IProductDal repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
