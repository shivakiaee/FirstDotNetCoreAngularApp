
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShipmentContext _shipmentContext;
        private IDriverRepository _driverRepository;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IBaseRepository<T> GetBaseRepository<T>() where T :BaseEntity
        {
            if(repositories.ContainsKey(typeof(T)))
            {
                return repositories[typeof(T)] as IBaseRepository<T>;
            }
            else
            {
                BaseRepository<T> repository = new BaseRepository<T>(_shipmentContext);
                repositories.Add(typeof(T), repository);
                return repository;
            }
        }
       
        public UnitOfWork(ShipmentContext shipmentContext)
        {
            this._shipmentContext = shipmentContext;
        }
        
      
        public async Task<int> Save()
        {
          return await _shipmentContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public IDriverRepository DriverRepository
        {
            get { return _driverRepository != null ? _driverRepository : new DriverRepository(_shipmentContext); }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _shipmentContext.Dispose();
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
