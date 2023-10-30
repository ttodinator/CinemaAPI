using CinemaAPI.Entities;
using CinemaAPI.Repositories.Definition;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repositories.Implementation
{
    public class RepositoryReservation : IRepositoryReservation
    {
        private readonly DataContext dataContext;


        public RepositoryReservation(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<SeatReservation>> GetReservedSeatReservationForScreening(int screeningId)
        {
            var reservations = await dataContext.Reservation.Where(x => x.ScreeningId == screeningId).ToListAsync();
            int[] ids = new int[reservations.Count];
            int index = 0;
            foreach (var reservation in reservations)
            {
                ids[index] = reservation.Id;
                index++;
            }

            return await dataContext.SeatReservation.Where(x => ids.Contains(x.Reservationid)).ToListAsync();
        }

        public void Save(Reservation reservation)
        {
            dataContext.Add(reservation);
        }
    }
}
