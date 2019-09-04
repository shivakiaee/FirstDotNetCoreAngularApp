using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
namespace Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Remove(int id);
        IQueryable<T> GetAll();
    }
}
