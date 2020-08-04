using Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
                var user = await _unitOfWork.UserRepo.GetAll().Where(user => user.Email == email && user.IsRegistered).Include(b => b.Role).FirstOrDefaultAsync();

                if (user == null || !user.IsRegistered)
                    return null;

                if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                    return null;

                return user;
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
                bool userExists = await UserRegistered(user.Email);

                if (userExists)
                    return null;


                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Password = Convert.ToBase64String(passwordHash);
                user.IsRegistered = true;
                if(user.RoleId != 1)
                    user.RoleId = 2;
                else
                    user.RoleId = 1;

                await _unitOfWork.UserRepo.AddAsyn(user);

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

        public async Task<bool> UserRegistered(string email)
        {
            var user = await _unitOfWork.UserRepo.FindAsync(user => user.Email == email && user.IsRegistered);
            return user != null;
        }
    }
}