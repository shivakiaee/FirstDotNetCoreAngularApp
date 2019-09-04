using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Repository;
namespace Service
{
    public class DriverService : BaseService<Driver>, IDriverService
    {
        private IUnitOfWork _unitOfWork;
        public DriverService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override IQueryable<Driver> GetAll()
        {
            return _unitOfWork.DriverRepository.GetAll();
        }
    }

}
