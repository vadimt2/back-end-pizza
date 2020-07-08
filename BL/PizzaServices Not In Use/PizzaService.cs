using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.PizzaServices
{
    public class PizzaService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public PizzaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<Pizza>> Get()
        //{
        //    return await _unitOfWork.PizzaRepo.GetAllAsyn();
        //}

        //public async Task<Pizza> Get(int id)
        //{
        //    return await _unitOfWork.PizzaRepo.GetAsync(id);
        //}

        //public async Task<Pizza> Inseret(Pizza pizza)
        //{
        //    return await _unitOfWork.PizzaRepo.AddAsyn(pizza);
        //}

        //public async Task<Pizza> Update(int id, Pizza pizza)
        //{
        //    return await _unitOfWork.PizzaRepo.UpdateAsyn(pizza, id);
        //}

        //public async Task<int> Delete(int id)
        //{
        //    var pizza = await Get(id);
        //    return await _unitOfWork.PizzaRepo.DeleteAsyn(pizza);
        //}

    }
}
