using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface ICategoryItemsService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<CategoryItems>> Get();
        Task<CategoryItems> Get(int id);
        Task<CategoryItems> Inseret(CategoryItems catrgoryItems);
        Task<CategoryItems> Update(int id, CategoryItems catrgoryItems);
    }
}