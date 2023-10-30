using CinemaAPI.DTOs;
using CinemaAPI.Entities;
using CinemaAPI.Extensions;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class ReservationController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public ReservationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddReservation(AddReservationDto dto)
        {
            var userId = User.GetUserId();

            Reservation reservation = new Reservation
            {
                Active = true,
                AppUserId = userId,
                ScreeningId = dto.ScreeningId,
            };
            if (dto.SeatReservations != null && dto.SeatReservations.Count > 0)
            {
                reservation.SeatReservations = new List<SeatReservation>();
                foreach (var item in dto.SeatReservations)
                {
                    SeatReservation seatRes = new SeatReservation
                    {
                        HallId = item.HallId,
                        SeatId = item.SeatId
                    };
                    reservation.SeatReservations.Add(seatRes);
                }

            }
            //Movie movie = new Movie
            //{
            //    Name = movieDto.Name,
            //    Description = movieDto.Description,
            //    GenreId = movieDto.GenreId,
            //    DirectorId = movieDto.DirectorId,
            //    ReleaseDate = movieDto.ReleaseDate,
            //};
            //if (movieDto.Roles != null && movieDto.Roles.Count > 0)
            //{
            //    movie.Roles = new List<Role>();
            //    foreach (Role role in movieDto.Roles)
            //    {
            //        if (role != null)
            //        {
            //            Role role1 = new Role
            //            {
            //                Id = role.Id,
            //                MainRole = role.MainRole,
            //                ActorId = role.ActorId,
            //                RoleName = role.RoleName,
            //            };
            //            movie.Roles.Add(role1);
            //        }
            //    }
            //}
            unitOfWork.RepositoryReservation.Save(reservation);
            if (await unitOfWork.Complete()) return Ok();
            return BadRequest();
        }

        [HttpGet("get-seat-reservations/{screeningId}")]
        public async Task<ActionResult<List<SeatReservation>>> GetMovie(string screeningId)
        {
            int scId = Convert.ToInt32(screeningId);
            return await unitOfWork.RepositoryReservation.GetReservedSeatReservationForScreening(scId);
        }
    }
}
