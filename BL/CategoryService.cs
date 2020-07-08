using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _unitOfWork.CategoryRepo.GetAllAsyn();
        }

        public async Task<Category> Get(int id)
        {
            return await _unitOfWork.CategoryRepo.GetAsync(id);
        }

        public async Task<Category> Inseret(Category category)
        {
            return await _unitOfWork.CategoryRepo.AddAsyn(category);
        }

        public async Task<Category> Update(int id, Category category)
        {
            return await _unitOfWork.CategoryRepo.UpdateAsyn(category, id);
        }

        public async Task<int> Delete(int id)
        {
            var category = await Get(id);
            return await _unitOfWork.CategoryRepo.DeleteAsyn(category);
        }

    }
}
