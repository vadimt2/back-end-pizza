using Common;
using Infrastructure;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _appContext;

        private IRepository<User> _userRepo;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IRepository<User> UserRepo 
        {
            get
            {
                if(_userRepo == null)
                    _userRepo = new Repository<User>(_appContext);

                return _userRepo;
            } 
        }
            

        public async Task<int> Save()
        {
            return await _appContext.SaveChangesAsync();
        }
    }
}
