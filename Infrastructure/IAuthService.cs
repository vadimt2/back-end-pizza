using Common;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IAuthService
    {
        Task<User> AuthenticateUser(string email, string password);
        Task<User> Register(User user);
        Task<bool> UserExists(string email);
    }
}