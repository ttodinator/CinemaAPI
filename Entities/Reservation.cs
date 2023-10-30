namespace CinemaAPI.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }
    }
}
