using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Model;
using System;
using System.Linq;

namespace Repository
{
    public  class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity
    {
        protected ShipmentContext shipmentContext;
        protected DbSet<T> dbSet;
        public BaseRepository(ShipmentContext _shipmentContext)
        {
            shipmentContext = _shipmentContext;
            this.dbSet = shipmentContext.Set<T>();
        }
        
        public virtual async Task<T> GetById(int id) => await this.dbSet.FindAsync(id);

        public virtual async Task Add(T entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
             dbSet.Attach(entity);
             shipmentContext.Entry(entity).State = EntityState.Modified;
        }

        public  virtual async Task Remove(int id)
        {
            var found = await GetById(id);
            if (shipmentContext.Entry(found).State == EntityState.Detached)
            {
                dbSet.Attach(found);
            }
            dbSet.Remove(found);
        }

        public virtual IQueryable<T> GetAll()
        {
            return shipmentContext.Set<T>().AsNoTracking();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    shipmentContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
