namespace CinemaAPI.DTOs
{
    public class AddReservationDto
    {
        public int ScreeningId { get; set; }
        public List<SeatReservationDto>? SeatReservations { get; set; }
    }
}
