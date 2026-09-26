using teremKezelo.Enums;

namespace teremKezelo.DTOS.ResourceDtos
{
    public class ResourceGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ResourceType ResourceType { get; set; }

        public int? CategoryId { get; set; }
        public int? LocationId { get; set; }

        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? RoomNumber { get; set; }
        public int? Capacity { get; set; }

        public string? InventoryNumber { get; set; }
        public bool? IsPortable { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
