using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IBaseRestAPIService<T>
    {
        Task<int> Delete(int item);
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Inseret(T item);
        Task<T> Update(int id, T item);
    }
}
