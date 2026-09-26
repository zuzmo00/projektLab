using teremKezelo.DTOS.LocationDtos;
using teremKezelo.DTOS.MaintanenceDtos;
using teremKezelo.DTOS.ReservationDtos;
using teremKezelo.DTOS.ResourceCategoryDtos;
using teremKezelo.Enums;

namespace teremKezelo.DTOS.ResourceDtos
{
    public class ResourceGetAdvancedDto
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
        public CategoryGetDto? Categorie { get; set; }
        public LocatonGetDto? Location { get; set; }
        public List<ReservationGetDto>? Reservations { get; set; } = new List<ReservationGetDto>();
        public List<MaintanenceGetDto>? MaintenancePeriods { get; set; } = new List<MaintanenceGetDto>();
    }
}
