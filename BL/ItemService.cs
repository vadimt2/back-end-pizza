using Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> Get()
        {
           return await _unitOfWork.ItemRepo.IncludeMultiple(i => i.Include(it => it.CategoryItems).ThenInclude(c => c.Category).Include(im => im.Images)).ToListAsync();
        }

        public async Task<Item> Get(int id)
        {
            return await _unitOfWork.ItemRepo.IncludeMultiple(i => i.Include(it => it.CategoryItems).ThenInclude(c => c.Category).Include(im => im.Images)).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Item> Inseret(Item item)
        {
            return await _unitOfWork.ItemRepo.AddAsyn(item);
        }

        public async Task<Item> Update(int id, Item item)
        {
            return await _unitOfWork.ItemRepo.UpdateAsyn(item, id);
        }

        public async Task<int> Delete(int id)
        {
            var item = await Get(id);
            return await _unitOfWork.ItemRepo.DeleteAsyn(item);
        }

    }
}
