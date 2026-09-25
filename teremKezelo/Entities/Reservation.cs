using teremKezelo.Enums;

namespace teremKezelo.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ReservationStatus Status { get; set; }
        public string Purpose { get; set; }
        public string Note { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CancelledAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? RejectedAt { get; set; }
    }
}
