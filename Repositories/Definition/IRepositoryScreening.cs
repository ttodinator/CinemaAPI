using CinemaAPI.DTOs;
using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryScreening
    {
        void Save(Screening screening);
        public Task<List<Screening>> GetBySearchParams(SearchScreeningDto dto);
        Task<Screening> GetScreeningById(int screeningId);

        void DeleteScreeningById(Screening screening);
        void Update(Screening screening);

    }
}
