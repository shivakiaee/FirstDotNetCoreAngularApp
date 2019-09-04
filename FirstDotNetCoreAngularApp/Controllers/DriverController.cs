using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViewModel;
namespace FirstDotNetCoreAngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;
        public DriverController(IDriverService _driverService)
        {
            driverService = _driverService;
        }

        [HttpGet]
        public async  Task<IEnumerable<DriverViewModel>> GetAll()
        {
            var drivers= await driverService.GetAll().ToListAsync();
            return DriverViewModel.GetViewModels< DriverViewModel>(drivers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverViewModel>> GetDirver(int id)
        {
            var driver = await driverService.GetById(id);
            return DriverViewModel.GetViewModel<DriverViewModel>(driver);

        }

        [HttpPost]
        public async Task<ActionResult<DriverViewModel>> PostDriver(DriverViewModel driver)
        {
           await driverService.Insert(driver.GetModel());
           return  CreatedAtAction("GetDirver", new { id = driver.Id }, driver);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(int id, Driver driver)
        {
            if(id!=driver.Id)
            {
                return BadRequest();
            }
            try
            {
                await driverService.Update(driver);
            }
            catch (DbUpdateConcurrencyException)
            {
                var found= await driverService.GetById(id);
                if (found == null)
                {
                    return NotFound();
                }
                else
                    throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DriverViewModel>> DeleteDriver(int id)
        {
            var founddriver = await driverService.GetById(id);
            if (founddriver == null)
            {
                return NotFound();
            }
            await driverService.Remove(id);
            return DriverViewModel.GetViewModel<DriverViewModel>(founddriver);
        }
    }
}