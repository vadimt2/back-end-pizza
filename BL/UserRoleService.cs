using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _unitOfWork.RoleRepo.GetAllAsyn();
        }

        public async Task<Role> Get(int id)
        {
            return await _unitOfWork.RoleRepo.GetAsync(id);
        }

        public async Task<Role> Inseret(Role role)
        {
            return await _unitOfWork.RoleRepo.AddAsyn(role);
        }

        public async Task<Role> Update(int id, Role role)
        {
            return await _unitOfWork.RoleRepo.UpdateAsyn(role, id);
        }

        public async Task<int> Delete(int id)
        {
            var role = await Get(id);
            return await _unitOfWork.RoleRepo.DeleteAsyn(role);
        }

    }
}
