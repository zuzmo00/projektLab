using teremKezelo.Entities;
using teremKezelo.Enums;

namespace teremKezelo.DTOS.ReservationDtos
{
    public class ReservationCreateDto
    {

        public int ResourceId { get; set; }

        public string UserId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ReservationStatus Status { get; set; }
        public string Purpose { get; set; }
        public string Note { get; set; }

    }
}
