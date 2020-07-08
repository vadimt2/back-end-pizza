using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ShippingService : IShippingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShippingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Shipping>> Get()
        {
            return await _unitOfWork.ShippingRepo.GetAllAsyn();
        }

        public async Task<Shipping> Get(int id)
        {
            return await _unitOfWork.ShippingRepo.GetAsync(id);
        }

        public async Task<Shipping> Inseret(Shipping shipping)
        {
            return await _unitOfWork.ShippingRepo.AddAsyn(shipping);
        }

        public async Task<Shipping> Update(int id, Shipping shipping)
        {
            return await _unitOfWork.ShippingRepo.UpdateAsyn(shipping, id);
        }

        public async Task<int> Delete(int id)
        {
            var shipping = await Get(id);
            return await _unitOfWork.ShippingRepo.DeleteAsyn(shipping);
        }

    }
}