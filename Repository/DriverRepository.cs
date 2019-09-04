using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq;

namespace Repository
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ShipmentContext shipmentContext) :base(shipmentContext)
        {
        }
        public override IQueryable<Driver> GetAll()
        {
           return base.shipmentContext.Drivers.Include("City").AsNoTracking();
        }
    }
}
