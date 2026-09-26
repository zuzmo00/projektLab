using teremKezelo.Enums;

namespace teremKezelo.DTOS.ResourceDtos
{
    public class ResourceFilterDto
    {
        public ResourceType? ResourceType { get; set; }
        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }
        public bool? IsActive { get; set; }

        public string? SortBy { get; set; }
    }
}
