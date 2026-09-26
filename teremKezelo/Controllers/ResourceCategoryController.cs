using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teremKezelo.DTOS.ResourceCategoryDtos;
using teremKezelo.Services;

namespace teremKezelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceCategoryController : ControllerBase
    {
        private readonly IResourceCategoryService _resourceCategoryService;
        public ResourceCategoryController(IResourceCategoryService resourceCategoryService)
        {
            _resourceCategoryService = resourceCategoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResourceCategoryCreateDto resourceCategoryCreateDto)
        {
            try
            {
                var createdResourceCategory = await _resourceCategoryService.CreateResourceCategoryAsync(resourceCategoryCreateDto);
                return Ok(createdResourceCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
