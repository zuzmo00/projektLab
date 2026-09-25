namespace teremKezelo.Entities
{
    public class MaintenancePeriod
    {
        public int Id { get; set; }


        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Reason { get; set; }

        public DateTime CreatedAt { get; set; }=DateTime.UtcNow;
        public string CreatedByUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
