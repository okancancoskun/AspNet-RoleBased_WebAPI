using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.Business.Interfaces;
using Project.API.Dtos.Dtos.Category;
using Project.API.Entities.Concrete;

namespace Project.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());

        }
        [HttpPost("create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddProduct(CreateCategoryDto createCategoryDto, [FromServices] IUserService userService)
        {

            await _categoryService.Add(_mapper.Map<Category>(createCategoryDto));
            return Created("", createCategoryDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _categoryService.FindById(id));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await _categoryService.Remove(new Category { Id = id });
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOne(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (id != updateCategoryDto.Id) return BadRequest("Product Does Not Exist");
            await _categoryService.Update(_mapper.Map<Category>(updateCategoryDto));
            return NoContent();
        }
    }
}