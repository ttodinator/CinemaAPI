using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryUser
    {
        Task<AppUser> GetUser(int id);
        public void UpdateProfilePhoto(AppUser user);
        Task<AppUser> GetReservationForUser(int id);
        void Update(AppUser user);
    }
}
