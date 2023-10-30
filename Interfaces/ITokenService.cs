using CinemaAPI.Entities;

namespace CinemaAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
