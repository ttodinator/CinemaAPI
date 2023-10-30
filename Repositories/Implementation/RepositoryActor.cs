using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryActor : IRepositoryActor
    {
        private readonly DataContext dataContext;

        public RepositoryActor(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<List<Actor>> GetAll()
        {
            return await dataContext.Actor.ToListAsync();

        }
    }
}
