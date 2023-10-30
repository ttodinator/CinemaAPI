using CinemaAPI.Entities;

namespace CinemaAPI.DTOs
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public int? DirectorId { get; set; }
        public int? GenreId { get; set; }
        public List<Role>? Roles { get; set; }

    }
}
