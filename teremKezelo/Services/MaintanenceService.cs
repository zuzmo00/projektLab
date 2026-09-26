using AutoMapper;
using teremKezelo.DbCOntext;
using teremKezelo.DTOS.MaintanenceDtos;
using teremKezelo.Entities;

namespace teremKezelo.Services
{
    public interface IMaintanenceService
    {
        public Task<MaintenancePeriod> CreateMaintanenceAsync(ManitanenceCreateDto maintanence);
    }
    public class MaintanenceService : IMaintanenceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MaintanenceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MaintenancePeriod> CreateMaintanenceAsync(ManitanenceCreateDto maintanence)
        {
            var entity = _mapper.Map<MaintenancePeriod>(maintanence);
            return entity;
        }
    }
}
