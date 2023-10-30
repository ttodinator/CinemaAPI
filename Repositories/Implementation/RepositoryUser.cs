using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly DataContext dataContext;

        public RepositoryUser(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<AppUser> GetReservationForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await dataContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public void Update(AppUser user)
        {
            dataContext.Entry(user).State = EntityState.Modified;
        }

        public void UpdateProfilePhoto(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
