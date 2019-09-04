using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
namespace Repository
{
    public interface IBaseRepository<T>: IDisposable where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task Add(T entity) ;
        void Update(T entity);
        Task Remove(int id);
        IQueryable<T> GetAll();
       
    }
}
