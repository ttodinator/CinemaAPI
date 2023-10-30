namespace CinemaAPI.Entities
{
    public class Hall
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Capacity { get; set; }
        public List<Screening>? Screenings { get; set; }
        public List<Seat>? Seats { get; set; }
    }
}
