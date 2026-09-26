using teremKezelo.DTOS.ResourceDtos;
using teremKezelo.DbCOntext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace teremKezelo.Services
{
    public interface IResourceService
    {
        public Task<List<ResourceGetDto>> GetAllResourcesAsync(ResourceFilterDto filterDto  );
        public Task<ResourceCreateDto> GetResourceByIdAsync(int id);
        public Task<ResourceGetAdvancedDto> GetResourceByIdAdvancedAsync(int id);
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

        public async Task<List<ResourceGetDto>> GetAllResourcesAsync(ResourceFilterDto filterDto)
        {
            var query = _context.Resources.AsQueryable();
            if (filterDto.ResourceType.HasValue)
            {
                query = query.Where(r => r.ResourceType == filterDto.ResourceType.Value);
            }
            if (filterDto.CategoryId.HasValue)
            {
                query = query.Where(r => r.CategoryId == filterDto.CategoryId.Value);
            }
            if (filterDto.IsActive.HasValue)
            {
                query = query.Where(r => r.IsActive == filterDto.IsActive.Value);
            }
            if(filterDto.LocationId.HasValue)
            {
                query = query.Where(r => r.LocationId == filterDto.LocationId.Value);
            }

            if (!string.IsNullOrEmpty(filterDto.SortBy))
            {
                if(filterDto.SortBy.ToLower() == "name")
                {
                    query = query.OrderBy(r => r.Name);
                }
                else if (filterDto.SortBy.ToLower() == "location")
                {
                    query = query.OrderBy(r => r.LocationId);
                }
            }
            var entities = await query.ToListAsync();
            return _mapper.Map<List<ResourceGetDto>>(entities);
        }

        public async Task<ResourceGetAdvancedDto> GetResourceByIdAdvancedAsync(int id)
        {
            var res= await _context.Resources.Where(r => r.Id == id)
                .Include(r => r.Category)
                .Include(r => r.Location)
                .Include(r => r.Reservations)
                .Include(r => r.MaintenancePeriods)
                .FirstOrDefaultAsync();
            if(res==null)
            {
                throw new Exception("Resource not found");
            }
            return _mapper.Map<ResourceGetAdvancedDto>(res);
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
