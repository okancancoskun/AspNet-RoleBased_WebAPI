using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Project.API.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser user, Role role);

    }
}
