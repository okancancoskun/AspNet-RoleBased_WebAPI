using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.Business.Interfaces;
using Project.API.Dtos.Dtos.User;
using Project.API.Entities.Concrete;

namespace Project.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IUserService userService, IMapper mapper)
        {
            _jwtService = jwtService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var user = await _userService.FindByUserName(userRegisterDto.Username);
            if (user != null)
            {
                return BadRequest("User Already Exist");
            }
            else
            {
                await _userService.Add(_mapper.Map<AppUser>(userRegisterDto));
                return Created("", userRegisterDto);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, [FromServices] IRoleService roleService)
        {
            var user = await _userService.FindByUserName(userLoginDto.Username);

            if (user == null)
            {
                return BadRequest("User Does Not Exist");
            }
            else
            {
                var role = await roleService.FindById(user.RoleId);
                if (await _userService.CheckPassword(userLoginDto))
                {
                    var token = _jwtService.GenerateJwt(user, role);
                    var data = new { token, user = new { user.Id, user.Username, role = role.Name } };
                    return Created("", data);
                }
                else
                {
                    return BadRequest("Email or Password is not correct.");
                }
            }
        }
    }
}