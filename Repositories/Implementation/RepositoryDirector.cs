using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryDirector : IRepositoryDirector
    {
        private readonly DataContext dataContext;

        public RepositoryDirector(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<List<Director>> GetAll()
        {
            return await dataContext.Director.ToListAsync();

        }
    }
}
