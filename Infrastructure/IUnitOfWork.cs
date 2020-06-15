using Common;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepo { get;  }

        Task<int> Save();
    }
}
