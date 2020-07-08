using Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderDetails>> Get()
        {
            return await _unitOfWork.OrderDetailsRepo.GetAllAsyn();
        }

        public async Task<OrderDetails> Get(int id)
        {
            return await _unitOfWork.OrderDetailsRepo.GetAsync(id);
        }

        public async Task<OrderDetails> Inseret(OrderDetails orderDetails)
        {
            return await _unitOfWork.OrderDetailsRepo.AddAsyn(orderDetails);
        }

        public async Task<OrderDetails> Update(int id, OrderDetails orderDetails)
        {
            return await _unitOfWork.OrderDetailsRepo.UpdateAsyn(orderDetails, id);
        }

        public async Task<int> Delete(int id)
        {
            var orderDetails = await Get(id);
            return await _unitOfWork.OrderDetailsRepo.DeleteAsyn(orderDetails);
        }

    }
}
