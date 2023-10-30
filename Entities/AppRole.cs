using Microsoft.AspNetCore.Identity;

namespace CinemaAPI.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public List<AppUserRole>? UserRoles { get; set; }
    }
}
