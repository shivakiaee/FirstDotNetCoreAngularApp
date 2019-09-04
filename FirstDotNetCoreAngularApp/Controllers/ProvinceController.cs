using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstDotNetCoreAngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IBaseService<Province> provinceService;
        public ProvinceController(IBaseService<Province> _provinceService)
        {
            provinceService = _provinceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Province>> Get()
        {
            var provinces = await provinceService.GetAll().ToListAsync();
            return provinces;
        }
    }
}