using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrafficManagementSystem.Application.DTOs.OffenceType;
using TrafficManagementSystem.Application.Interfaces.Services;

namespace TrafficManagementSystem.API.Controllers
{
    [Authorize]
    [Route("api/offenceTypes")]
    [ApiController]
    public class OffenceTypesController : ControllerBase
    {
        private IOffenceTypeService _offenceTypeService;

        public OffenceTypesController(IOffenceTypeService offenceTypesService)
        {
            _offenceTypeService = offenceTypesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOffence(NewOffenceTypeRequest request)
        {
            var response = await _offenceTypeService.AddOffenceTypeAsync(request);
            return CreatedAtAction(nameof(GetOffence), new { id = response.Data.Id }, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetOffenceTypes() => Ok(await _offenceTypeService.GetAllOffenceTypes());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffence([FromRoute] Guid id) => Ok(await _offenceTypeService.GetOffenceTypeById(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffence(Guid id)
        {
            await _offenceTypeService.DeleteOffenceTypeAsync(id);
            return NoContent();
        }

        [HttpGet("codes")]
        public async Task<IActionResult> GetOffenceTypeCodes()
            => Ok(await _offenceTypeService.GetOffenceTypeCodes());


    }
}
