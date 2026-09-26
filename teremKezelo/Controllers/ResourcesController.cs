using Microsoft.AspNetCore.Mvc;
using teremKezelo.DTOS.ResourceDtos;
using teremKezelo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teremKezelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResourceCreateDto resourceCreateDto)
        {
            try
            {
                await _resourceService.CreateResourceAsync(resourceCreateDto);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resource = await _resourceService.GetResourceByIdAsync(id);
                return Ok(resource);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ResourceFilterDto filterDto)
        {
            try
            {
                var resources = await _resourceService.GetAllResourcesAsync(filterDto);
                return Ok(resources);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}/advanced")]
        public async Task<IActionResult> GetAdvanced(int id)
        {
            try
            {
                var resource = await _resourceService.GetResourceByIdAdvancedAsync(id);
                return Ok(resource);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}