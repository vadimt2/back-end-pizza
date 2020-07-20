using Common;
using Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IImagesService
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Image>> Get();
        Task<Image> Get(int id);
        Task<Image> Inseret(Image image);
        Task<Image> Update(int id, Image image);
    }
}