using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Services;

namespace TrafficManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
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
            var driver = _driverService.AddDriverAsync(request);
            return Ok(driver);
            //return CreatedAtAction(nameof(AddDriver), driver);
        }
    }
}
