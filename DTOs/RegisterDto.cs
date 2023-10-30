using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string? CellphoneNumber { get; set; }

        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string Password { get;  set; }
    }
}
