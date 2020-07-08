using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryItemsService : ICategoryItemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryItems>> Get()
        {
            return await _unitOfWork.CatItemsRepo.GetAllAsyn();
        }

        public async Task<CategoryItems> Get(int id)
        {
            return await _unitOfWork.CatItemsRepo.GetAsync(id);
        }

        public async Task<CategoryItems> Inseret(CategoryItems catrgoryItems)
        {
            return await _unitOfWork.CatItemsRepo.AddAsyn(catrgoryItems);
        }

        public async Task<CategoryItems> Update(int id, CategoryItems catrgoryItems)
        {
            return await _unitOfWork.CatItemsRepo.UpdateAsyn(catrgoryItems, id);
        }

        public async Task<int> Delete(int id)
        {
            var catrgoryItems = await Get(id);
            return await _unitOfWork.CatItemsRepo.DeleteAsyn(catrgoryItems);
        }
    }
}
