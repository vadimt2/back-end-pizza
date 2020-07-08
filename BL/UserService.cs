using Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _unitOfWork.UserRepo.GetAllAsyn();
        }

        public async Task<User> Get(int id)
        {
            return await _unitOfWork.UserRepo.GetAsync(id);
        }

        public async Task<User> Inseret(User user)
        {
            return await _unitOfWork.UserRepo.AddAsyn(user);
        }

        public async Task<User> Update(int id, User user)
        {
            return await _unitOfWork.UserRepo.UpdateAsyn(user, id);
        }

        public async Task<int> Delete(int id)
        {
            var user = await Get(id);
            return await _unitOfWork.UserRepo.DeleteAsyn(user);
        }

    }
}
