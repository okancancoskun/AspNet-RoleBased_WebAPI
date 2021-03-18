using AutoMapper;
using Project.API.Dtos.Dtos.Category;
using Project.API.Dtos.Dtos.Product;
using Project.API.Dtos.Dtos.Role;
using Project.API.Dtos.Dtos.User;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, CreateProductDto>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();

            CreateMap<CreateRoleDto, Role>();
            CreateMap<Role, CreateRoleDto>();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<Role, UpdateRoleDto>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>();

            CreateMap<UserRegisterDto, AppUser>();
            CreateMap<AppUser, UserRegisterDto>();
        }
    }
}
