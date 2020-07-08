using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface ICategoryService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(int id);
        Task<Category> Inseret(Category catrgory);
        Task<Category> Update(int id, Category catrgory);
    }
}