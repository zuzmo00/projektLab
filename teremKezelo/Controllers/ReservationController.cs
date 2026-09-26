using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teremKezelo.DTOS.ReservationDtos;
using teremKezelo.Services;

namespace teremKezelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservationCreateDto reservationCreateDto)
        {
            try
            {
                var createdReservation = await _reservationService.CreateReservationAsync(reservationCreateDto);
                return Ok(createdReservation);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
