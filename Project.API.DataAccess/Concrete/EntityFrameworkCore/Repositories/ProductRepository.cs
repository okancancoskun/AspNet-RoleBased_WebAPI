using Project.API.DataAccess.Interfaces;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductDal
    {
    }
}
