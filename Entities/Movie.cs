namespace CinemaAPI.Entities
{
    public class Movie
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public Director? Director { get; set; }
        public int? DirectorId { get; set; }
        public Genre? Genre { get; set; }
        public int? GenreId { get; set; }
        public List<Role>? Roles { get; set; }
        public List<Screening>? Screenings { get; set; }
    }
}
