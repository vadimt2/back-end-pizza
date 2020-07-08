using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUserRoleService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Role>> Get();
        Task<Role> Get(int id);
        Task<Role> Inseret(Role role);
        Task<Role> Update(int id, Role role);
    }
}