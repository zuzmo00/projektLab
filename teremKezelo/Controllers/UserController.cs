using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teremKezelo.DTOS.UserDtos;
using teremKezelo.Services;

namespace teremKezelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            try
            {
                var createdUser = await _userService.CreateUserAsync(userDto);
                return Ok();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the user.");
            }
        }
    }
}