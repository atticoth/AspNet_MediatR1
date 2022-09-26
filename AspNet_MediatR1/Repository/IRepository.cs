using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNet_MediatR1.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Edit(T item);
        Task Delete(int id);
    }
}
