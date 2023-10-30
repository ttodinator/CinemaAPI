namespace CinemaAPI.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }
        public Hall Hall { get; set; }
        public int HallId { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }
    }
}
