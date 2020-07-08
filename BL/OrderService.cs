using Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _unitOfWork.OrderRepo.GetAllAsyn();
        }

        public async Task<Order> Get(int id)
        {
            return await _unitOfWork.OrderRepo.GetAsync(id);
        }

        public async Task<Order> Inseret(Order order)
        {

            var user =_unitOfWork.UserRepo.Add(order.User);
            if(user != null)
            {
                order.Id = 0;
                order.UserId = user.Id;
                order.OrderDate = DateTime.Now;
                order.ConfirmationNumber = Guid.NewGuid();

                // Will be more logic added -> Vadim Tomashevsky

            }


            return await _unitOfWork.OrderRepo.AddAsyn(order);
        }

        public async Task<ICollection<Order>> GetHistoryOrders(string email)
        {
            var getOrders = await _unitOfWork.OrderRepo.IncludeMultiple(x => x.Include(j => j.BellingAndShippInfo)).Include(b => b.OrderDetails).ThenInclude(n => n.Item).ToListAsync();
            var searchByEmail = getOrders.Where(c => c.BellingAndShippInfo.Any(i => i.Email.Contains(email))).ToList();
            return searchByEmail;
        }

        public async Task<Order> Update(int id, Order order)
        {
            return await _unitOfWork.OrderRepo.UpdateAsyn(order, id);
        }

        public async Task<int> Delete(int id)
        {
            var order = await Get(id);
            return await _unitOfWork.OrderRepo.DeleteAsyn(order);
        }

    }
}
