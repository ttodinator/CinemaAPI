namespace CinemaAPI.Entities
{
    public class Screening
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public Movie? Movie { get; set; }
        public int? MovieId { get; set; }
        public Hall? Hall { get; set; }
        public int? HallId { get; set; }
        public double? Price { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
