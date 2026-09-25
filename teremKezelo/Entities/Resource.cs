using teremKezelo.Enums;

namespace teremKezelo.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ResourceType ResourceType { get; set; }


        public string? Building { get; set; }
        public string? Floor { get; set; }
        public string? RoomNumber { get; set; }
        public int? Capacity { get; set; }


        public string? InventoryNumber { get; set; }
        public bool? IsPortable { get; set; }


        public int? CategoryId { get; set; }
        public ResourceCategory Category { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }


        public bool IsActive { get; set; }
        public ResourceStatus Status { get; set; } = ResourceStatus.Available;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } 

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<MaintenancePeriod> MaintenancePeriods { get; set; } = new List<MaintenancePeriod>();
    }
}
