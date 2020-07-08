using Common;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ImagesService : IImagesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImagesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Image>> Get()
        {
            return await _unitOfWork.ImageRepo.GetAllAsyn();
        }

        public async Task<Image> Get(int id)
        {
            return await _unitOfWork.ImageRepo.GetAsync(id);
        }

        public async Task<Image> Inseret(Image image)
        {
            return await _unitOfWork.ImageRepo.AddAsyn(image);
        }

        public async Task<Image> Update(int id, Image image)
        {
            return await _unitOfWork.ImageRepo.UpdateAsyn(image, id);
        }

        public async Task<int> Delete(int id)
        {
            var image = await Get(id);
            return await _unitOfWork.ImageRepo.DeleteAsyn(image);
        }

    }
}
