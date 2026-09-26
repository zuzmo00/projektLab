using AutoMapper;
using Azure;
using teremKezelo.DbCOntext;
using teremKezelo.DTOS.ResourceCategoryDtos;
using teremKezelo.Entities;

namespace teremKezelo.Services
{
    public interface IResourceCategoryService
    {
        Task<ResourceCategory> CreateResourceCategoryAsync(ResourceCategoryCreateDto resourceCategoryCreateDto);
    }
    public class ResourceCategoryService :IResourceCategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ResourceCategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResourceCategory> CreateResourceCategoryAsync(ResourceCategoryCreateDto resourceCategoryCreateDto)
        {
            var entity = _mapper.Map<ResourceCategory>(resourceCategoryCreateDto);
            _context.ResourceCategories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
