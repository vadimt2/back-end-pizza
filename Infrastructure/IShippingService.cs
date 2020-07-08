using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IShippingService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Shipping>> Get();
        Task<Shipping> Get(int id);
        Task<Shipping> Inseret(Shipping shipping);
        Task<Shipping> Update(int id, Shipping shipping);
    }
}