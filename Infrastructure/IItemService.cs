using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IItemService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Item>> Get();
        Task<Item> Get(int id);
        Task<Item> Inseret(Item item);
        Task<Item> Update(int id, Item item);
    }
}