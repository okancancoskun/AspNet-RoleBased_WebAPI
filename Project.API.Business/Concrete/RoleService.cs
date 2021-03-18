using Project.API.Business.Interfaces;
using Project.API.DataAccess.Interfaces;
using Project.API.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Business.Concrete
{
    public class RoleService : GenericService<Role>, IRoleService
    {
        private readonly IRoleDal _repository;
        public RoleService(IRoleDal repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
