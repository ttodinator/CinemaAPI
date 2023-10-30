using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryGenre : IRepositoryGenre
    {
        private readonly DataContext dataContext;

        public RepositoryGenre(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<List<Genre>> GetAll()
        {
            return await dataContext.Genre.ToListAsync();
        }
    }
}
