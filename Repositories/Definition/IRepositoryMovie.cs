using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryMovie
    {
        void Save(Movie movie);
        Task<List<Movie>> GetAll();
        Task<List<Movie>> GetBySearchParams(Movie movie);
        Task<Movie> GetMovieById(int movieId);
        void Update(Movie movie);

    }
}
