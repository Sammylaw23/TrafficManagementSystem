using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Services;

namespace TrafficManagementSystem.API.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(NewDriverRequest request)
        {
            var response = await _driverService.AddDriverAsync(request);
            return CreatedAtAction(nameof(GetDriver), new { id = response.Data.Id }, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetDrivers() => Ok(await _driverService.GetAllDrivers());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver([FromRoute] Guid id) => Ok(await _driverService.GetDriverById(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(Guid id)
        {
            await _driverService.DeleteDriverAsync(id);
            return NoContent();
        }
    }
}
