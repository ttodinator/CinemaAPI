namespace CinemaAPI.DTOs
{
    public class UpdateScreeningDto
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
