using AutoMapper;
using teremKezelo.DbCOntext;
using teremKezelo.DTOS.ReservationDtos;
using teremKezelo.Entities;

namespace teremKezelo.Services
{
    public interface IReservationService
    {
        public Task<Reservation> CreateReservationAsync(ReservationCreateDto reservation);
    }
    public class ReservationService: IReservationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReservationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Reservation> CreateReservationAsync(ReservationCreateDto reservationDto)
        {
            var entity= _mapper.Map<Reservation>(reservationDto);
            await _context.Reservations.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
