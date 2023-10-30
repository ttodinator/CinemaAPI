using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryMovie : IRepositoryMovie
    {
        private readonly DataContext dataContext;


        public RepositoryMovie(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<List<Movie>> GetAll()
        {
            return dataContext.Movie.ToListAsync();
        }

        public async Task<List<Movie>> GetBySearchParams(Movie movie)
        {
            var query = dataContext.Movie.AsQueryable();
            if (movie.GenreId != null)
            {
                query = query.Where(x => x.GenreId == movie.GenreId);
            }
            if (movie.DirectorId != null) {
                query = query.Where(x => x.DirectorId == movie.DirectorId);
            }
            if (movie.ReleaseDate != null)
            {
                query = query.Where(x => x.ReleaseDate.Equals(movie.ReleaseDate));
            }
            if (movie.Name != null) {
                query = query.Where(x => x.Name == movie.Name); 
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            return await dataContext.Movie.Include(x => x.Roles).ThenInclude(m => m.Actor).FirstOrDefaultAsync(movie => movie.Id == movieId);
        }

        public void Save(Movie movie)
        {
            dataContext.Add(movie);
        }

        public void Update(Movie movie)
        {
            dataContext.Entry(movie).State = EntityState.Modified;
        }
    }
}
