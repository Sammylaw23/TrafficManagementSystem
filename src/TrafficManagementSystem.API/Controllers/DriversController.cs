using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using traffic_management_system.Application.DTOs.Driver;
using traffic_management_system.Application.Services;

namespace TrafficManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private DriverService _driverService;
        public async Task<IActionResult> AddDriver(NewDriverRequest request)
        {
            var driver = _driverService.AddDriverAsync(request);
            return Ok(driver);
            //return CreatedAtAction(nameof(AddDriver), driver);
        }
    }
}
