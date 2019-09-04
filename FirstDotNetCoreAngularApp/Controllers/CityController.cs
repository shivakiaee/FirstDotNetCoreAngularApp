using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Service;

namespace FirstDotNetCoreAngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IBaseService<City> cityService;
        public CityController(IBaseService<City> _cityService)
        {
            cityService = _cityService;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            var cities = await cityService.GetAll().ToListAsync();
            return cities;
        }
    }
}