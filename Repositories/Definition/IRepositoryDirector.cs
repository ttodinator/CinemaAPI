using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryDirector
    {
        Task<List<Director>> GetAll();
    }
}
