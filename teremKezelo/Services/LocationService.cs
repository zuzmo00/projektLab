using AutoMapper;
using teremKezelo.DbCOntext;
using teremKezelo.DTOS.LocationDtos;

namespace teremKezelo.Services
{
    public interface ILocationService
    {
        public Task<LocationCreateDto> CreateLocationAsync(LocationCreateDto location);
    }
    public class LocationService :ILocationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public LocationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LocationCreateDto> CreateLocationAsync(LocationCreateDto location)
        {
            var entity = _mapper.Map<Entities.Location>(location);
            _context.Locations.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<LocationCreateDto>(entity);
        }   
    }
}
