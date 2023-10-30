using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryHall
    {
        Task<List<Hall>> GetAll();
        Task<Hall> GetHallWithSeatsByHallId(int id);
        void Save(Hall hall);

    }
}
