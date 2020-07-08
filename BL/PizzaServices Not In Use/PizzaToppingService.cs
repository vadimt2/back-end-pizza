using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.PizzaServices
{
    public class PizzaToppingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PizzaToppingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<PizzaTopping>> Get()
        //{
        //    return await _unitOfWork.PizzaToppingRepo.GetAllAsyn();
        //}

        //public async Task<PizzaTopping> Get(int id)
        //{
        //    return await _unitOfWork.PizzaToppingRepo.GetAsync(id);
        //}

        //public async Task<PizzaTopping> Inseret(PizzaTopping pizzaTopping)
        //{
        //    return await _unitOfWork.PizzaToppingRepo.AddAsyn(pizzaTopping);
        //}

        //public async Task<PizzaTopping> Update(int id, PizzaTopping pizzaTopping)
        //{
        //    return await _unitOfWork.PizzaToppingRepo.UpdateAsyn(pizzaTopping, id);
        //}

        //public async Task<int> Delete(int id)
        //{
        //    var pizzaTopping = await Get(id);
        //    return await _unitOfWork.PizzaToppingRepo.DeleteAsyn(pizzaTopping);
        //}
    }
}
