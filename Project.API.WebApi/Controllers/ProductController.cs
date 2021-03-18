using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.API.Business.Interfaces;
using Project.API.Dtos.Dtos.Product;
using Project.API.Entities.Concrete;

namespace Project.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());

        }
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(CreateProductDto createProductDto, [FromServices] IUserService userService)
        {
            var findUser = await userService.FindByUserName(User.Identity.Name);
            createProductDto.AuthorId = findUser.Id;
            await _productService.Add(_mapper.Map<Product>(createProductDto));
            return Created("", createProductDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _productService.FindById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await _productService.Remove(new Product { Id = id });
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOne(int id, UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.Id) return BadRequest("Product Does Not Exist");
            await _productService.Update(_mapper.Map<Product>(updateProductDto));
            return NoContent();
        }
    }
}