using Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> AuthenticateUser(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.UserRepo.FindAsync(user => user.Email == email);
                if (user == null)
                    return null;

                if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                    return null;

                var userAndRole = await _unitOfWork.UserRepo.GetAllIncluding(role => role.Role).Where(role => role.RoleId == user.RoleId).FirstOrDefaultAsync();

                return userAndRole;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            try
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != passwordHash[i]) return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> Register(User user)
        {
            try
            {
                bool userExists = await UserExists(user.Email);
                if (userExists)
                    return null;


                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Password = Convert.ToBase64String(passwordHash);

                await _unitOfWork.UserRepo.AddAsyn(user);
                await _unitOfWork.Save();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string email)
        {
            var user = await _unitOfWork.UserRepo.FindAsync(user => user.Email == email);

            return user != null;
        }
    }
}