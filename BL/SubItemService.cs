using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubItemService : ISubItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<SubItem>> Get()
        //{
        //    return await _unitOfWork.SubItemRepo.GetAllAsyn();
        //}

        //public async Task<SubItem> Get(int id)
        //{
        //    return await _unitOfWork.SubItemRepo.GetAsync(id);
        //}

        //public async Task<SubItem> Inseret(SubItem subCat)
        //{
        //    return await _unitOfWork.SubItemRepo.AddAsyn(subCat);
        //}

        //public async Task<SubItem> Update(int id, SubItem subCat)
        //{
        //    return await _unitOfWork.SubItemRepo.UpdateAsyn(subCat, id);
        //}

        //public async Task<int> Delete(int id)
        //{
        //    var subCat = await Get(id);
        //    return await _unitOfWork.SubItemRepo.DeleteAsyn(subCat);
        //}

    }
}
