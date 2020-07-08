using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUserService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<User>> Get();
        Task<User> Get(int id);
        Task<User> Inseret(User user);
        Task<User> Update(int id, User user);
    }
}