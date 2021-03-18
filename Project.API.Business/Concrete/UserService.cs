using Project.API.Business.Interfaces;
using Project.API.DataAccess.Interfaces;
using Project.API.Dtos.Dtos.User;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.Concrete
{
    public class UserService : GenericService<AppUser>, IUserService
    {
        private readonly IUserDal _repository;
        public UserService(IUserDal repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _repository.GetByFilter(I => I.Username == userName);
        }
        public async Task<bool> CheckPassword(UserLoginDto userLoginDto)
        {
            var user = await _repository.GetByFilter(I => I.Username == userLoginDto.Username);
            return user.Password == userLoginDto.Password ? true : false;
        }

    }
}
