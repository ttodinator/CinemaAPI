using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryHall : IRepositoryHall
    {
        private readonly DataContext dataContext;

        public RepositoryHall(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<List<Hall>> GetAll()
        {
            return await dataContext.Hall.ToListAsync();
        }

        public async Task<Hall> GetHallWithSeatsByHallId(int id)
        {
            return await dataContext.Hall.Where(u => u.Id == id).Include(u => u.Seats).FirstOrDefaultAsync();

        }

        public void Save(Hall hall)
        {
            dataContext.Add(hall);
        }
    }
}
