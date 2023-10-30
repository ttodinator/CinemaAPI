using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Entities
{
    public class Role
    {
        public int? Id { get; set; }
        public string? RoleName { get; set; }
        public bool? MainRole { get; set; }
        public Movie? Movie { get; set; }
        public int? MovieId { get; set; }
        public Actor? Actor { get; set; }
        public int? ActorId { get; set; }
    }
}
