namespace CinemaAPI.DTOs
{
    public class SearchScreeningDto
    {
        public DateTime? Date { get; set; }
        public int? MovieId { get; set; }
        public int? DirectorId { get; set; }
        public int? GenreId { get; set; }
    }
}
