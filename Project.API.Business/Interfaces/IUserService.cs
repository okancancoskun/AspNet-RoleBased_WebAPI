using Project.API.Dtos.Dtos.User;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.Interfaces
{
    public interface IUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(UserLoginDto userLoginDto);
    }
}
