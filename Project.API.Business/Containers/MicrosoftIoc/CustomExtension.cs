using Microsoft.Extensions.DependencyInjection;
using Project.API.Business.Concrete;
using Project.API.Business.Interfaces;
using Project.API.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Project.API.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleDal, RoleRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDal, UserRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDal, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDal, UserRepository>();

            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
