using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IOrderService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Order>> Get();
        Task<Order> Get(int id);
        Task<Order> Inseret(Order order);
        Task<Order> Update(int id, Order order);
        Task<ICollection<Order>> GetHistoryOrders(string email);
    }
}