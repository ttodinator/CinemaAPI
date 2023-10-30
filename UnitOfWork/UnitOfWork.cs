using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using CinemaAPI.Repositories.Implementation;

namespace CinemaAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext dataContext { get; set; }

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IRepositoryUser RepositoryUser => new RepositoryUser(dataContext);

        public IRepositoryActor RepositoryActor => new RepositoryActor(dataContext);
        public IRepositoryDirector RepositoryDirector => new RepositoryDirector(dataContext);
        public IRepositoryGenre RepositoryGenre => new RepositoryGenre(dataContext);
        public IRepositoryMovie RepositoryMovie => new RepositoryMovie(dataContext);
        public IRepositoryScreening RepositoryScreening => new RepositoryScreening(dataContext);
        public IRepositoryHall RepositoryHall => new RepositoryHall(dataContext);
        public IRepositoryReservation RepositoryReservation => new RepositoryReservation(dataContext);

        public async Task<bool> Complete()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }

        public bool HasChanged()
        {
            throw new NotImplementedException();
        }
    }
}
