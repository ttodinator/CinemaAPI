using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryActor
    {
        Task<List<Actor>> GetAll();
    }
}
