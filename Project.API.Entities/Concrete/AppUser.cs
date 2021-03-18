using Microsoft.AspNet.Identity.EntityFramework;
using Project.API.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
