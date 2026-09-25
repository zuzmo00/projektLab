using teremKezelo.DTOS.ResourceDtos;
using teremKezelo.DbCOntext;
using AutoMapper;

namespace teremKezelo.Services
{
    public interface IResourceService
    {
        public Task<ResourceCreateDto> GetResourceByIdAsync(int id);
        public Task<ResourceCreateDto> CreateResourceAsync(ResourceCreateDto resource);
    }
    public class ResourceService : IResourceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ResourceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResourceCreateDto> CreateResourceAsync(ResourceCreateDto resource)
        {
            var entity = _mapper.Map<Entities.Resource>(resource);
            _context.Resources.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResourceCreateDto>(entity);
        }
        public async Task<ResourceCreateDto> GetResourceByIdAsync(int id)
        {
            var entity = await _context.Resources.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Resource not found");
            }
            return _mapper.Map<ResourceCreateDto>(entity);
        }
    }
}
