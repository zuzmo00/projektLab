namespace teremKezelo.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
    }
}
