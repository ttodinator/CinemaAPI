using CinemaAPI.DTOs;
using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryScreening : IRepositoryScreening
    {
        private readonly DataContext dataContext;

        public RepositoryScreening(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void DeleteScreeningById(Screening screening)
        {
            dataContext.Remove(screening);
        }

        public async Task<List<Screening>> GetBySearchParams(SearchScreeningDto dto)
        {
            var query = dataContext.Screening.Include(x => x.Movie).AsNoTracking();

            if (dto.GenreId != null)
            {
                query = query.Where(x => x.Movie.GenreId == dto.GenreId);
            }
            if (dto.DirectorId != null)
            {
                query = query.Where(x => x.Movie.DirectorId == dto.DirectorId);
            }
            if (dto.Date != null)
            {
                query = query.Where(x => (x.Date.Value.Date.Equals(dto.Date)));
            }
            if (dto.MovieId != null)
            {
                query = query.Where(x => x.MovieId == dto.MovieId);
            }

            return await query.Include(x=>x.Hall).AsNoTracking().ToListAsync();
        }

        public async Task<Screening> GetScreeningById(int screeningId)
        {
            return await dataContext.Screening.Include(x => x.Movie).ThenInclude(a=>a.Roles).ThenInclude(a=>a.Actor).Include(m => m.Hall).FirstOrDefaultAsync(movie => movie.Id == screeningId);
        }

        public void Save(Screening screening)
        {
            dataContext.Add(screening);
        }

        public void Update(Screening screening)
        {
            dataContext.Entry(screening).State = EntityState.Modified;
        }
    }
}
