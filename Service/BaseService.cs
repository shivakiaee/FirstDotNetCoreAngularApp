
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private IUnitOfWork unitOfWork;
        public BaseService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }
        public virtual async Task Insert(T entity)
        {
           await unitOfWork.GetBaseRepository<T>().Add(entity);
            await unitOfWork.Save();
        }


        public virtual IQueryable<T> GetAll()
        {
            return (IQueryable<T>)unitOfWork.GetBaseRepository<T>().GetAll() ;
        }

        public async  Task<T> GetById(int id)
        {
            return await unitOfWork.GetBaseRepository<T>().GetById(id);
        }

        public async Task Remove(int id)
        {
           await unitOfWork.GetBaseRepository<T>().Remove(id);
            await unitOfWork.Save();
        }

        public async Task Update(T entity)
        {
            unitOfWork.GetBaseRepository<T>().Update(entity);
            await  unitOfWork.Save();
        }

      
    }
}
