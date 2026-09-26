using teremKezelo.Entities;

namespace teremKezelo.DTOS.MaintanenceDtos
{
    public class ManitanenceCreateDto
    {
        public int ResourceId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }
        public string CreatedByUserId { get; set; }
        public bool IsActive { get; set; }
    }
}