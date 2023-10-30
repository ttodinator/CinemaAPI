using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryGenre
    {
        Task<List<Genre>> GetAll();
    }
}
