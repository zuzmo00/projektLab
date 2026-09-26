using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teremKezelo.DTOS.MaintanenceDtos;
using teremKezelo.Services;

namespace teremKezelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenenceController : ControllerBase
    {
        private readonly IMaintanenceService _maintenenceService;
        public MaintenenceController(IMaintanenceService maintenenceService)
        {
            _maintenenceService = maintenenceService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ManitanenceCreateDto maintenenceCreateDto)
        {
            try
            {
                var createdMaintenence = await _maintenenceService.CreateMaintanenceAsync(maintenenceCreateDto);
                return Ok(createdMaintenence);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
