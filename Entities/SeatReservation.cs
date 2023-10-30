namespace CinemaAPI.Entities
{
    public class SeatReservation
    {
        public int Reservationid { get; set; }
        public Reservation Reservation{ get; set; }
        public Seat Seat { get; set; }
        public int SeatId { get; set; }
        public Hall Hall { get; set; }
        public int HallId { get; set; }

    }
}
