using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrafficManagementSystem.Application.DTOs.Vehicle;
using TrafficManagementSystem.Application.Interfaces.Services;

namespace TrafficManagementSystem.API.Controllers
{
    [Authorize]
    [Route("api/vehicle")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(NewVehicleRequest request)
        {
            var response = await _vehicleService.AddVehicleAsync(request);
            return CreatedAtAction(nameof(GetVehicle), new { id = response.Data.Id }, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetVehicles() => Ok(await _vehicleService.GetAllVehicles());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle([FromRoute] Guid id) => Ok(await _vehicleService.GetVehicleById(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}
