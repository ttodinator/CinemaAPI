using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;

namespace CinemaAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepositoryUser RepositoryUser { get; }
        public IRepositoryActor RepositoryActor { get; }
        public IRepositoryDirector RepositoryDirector { get; }
        public IRepositoryGenre RepositoryGenre { get; }
        public IRepositoryMovie RepositoryMovie { get; }
        public IRepositoryScreening RepositoryScreening { get; }
        public IRepositoryHall RepositoryHall { get; }
        public IRepositoryReservation RepositoryReservation { get; }
        public DataContext dataContext { get; set; }
        Task<bool> Complete();
        bool HasChanged();
    }
}
