using Model;
using System;
using System.Threading.Tasks;

namespace Repository
{
   public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<T> GetBaseRepository<T>() where T : BaseEntity;
        IDriverRepository DriverRepository { get; }
        Task<int> Save();
      
    }
}
