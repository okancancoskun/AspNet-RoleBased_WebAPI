using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.Business.Interfaces;
using Project.API.Dtos.Dtos.Role;
using Project.API.Entities.Concrete;

namespace Project.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());

        }
        [HttpPost("create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateRoleDto createRoleDto)
        {

            await _roleService.Add(_mapper.Map<Role>(createRoleDto));
            return Created("", createRoleDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _roleService.FindById(id));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await _roleService.Remove(new Role { Id = id });
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOne(int id, UpdateRoleDto updateRoleDto)
        {
            if (id != updateRoleDto.Id) return BadRequest("Product Does Not Exist");
            await _roleService.Update(_mapper.Map<Role>(updateRoleDto));
            return NoContent();
        }
    }
}