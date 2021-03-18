using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Dtos.Dtos.User
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
