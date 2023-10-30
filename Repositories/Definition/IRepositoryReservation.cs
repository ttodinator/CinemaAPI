using CinemaAPI.Entities;

namespace CinemaAPI.Repositories.Definition
{
    public interface IRepositoryReservation
    {
        void Save(Reservation reservation);
        Task<List<SeatReservation>> GetReservedSeatReservationForScreening(int screeningId);

    }
}
