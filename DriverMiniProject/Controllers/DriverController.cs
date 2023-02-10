using DriverMiniProject.Model;
using DriverMiniProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriverMiniProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        // GET: api/<GetDriver>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(Guid id)
        {
            var driver = driverService.getDriverById(id);

            if(driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        // GET api/<GetAllDrivers>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDrivers()
        {
            return Ok(driverService.getAllDrivers());
        }

        // POST api/<CreateDriver>
        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] Driver driver)
        {
            Guid guid = Guid.NewGuid();
            driver.id = guid;
            return Ok(driverService.createDriver(driver));
        }

        // PUT api/<UpdateDriver>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(Guid id, [FromBody] Driver driver)
        {
            if(driverService.getDriverById(id) != null)
            {
                return Ok(driverService.updateDriverDetails(id, driver));
            }
            return NotFound();
        }

        // DELETE api/<DeleteDriver>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(Guid id)
        {
            if (driverService.getDriverById(id) != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
