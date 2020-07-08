using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IOrderDetailsService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<OrderDetails>> Get();
        Task<OrderDetails> Get(int id);
        Task<OrderDetails> Inseret(OrderDetails orderDetails);
        Task<OrderDetails> Update(int id, OrderDetails orderDetails);
    }
}