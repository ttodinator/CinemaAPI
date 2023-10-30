using CinemaAPI.Entities;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class HallController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public HallController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Hall>>> GetAllGenre()
        {
            return await unitOfWork.RepositoryHall.GetAll();
        }
        [HttpGet("get/{hallId}")]
        public async Task<ActionResult<Hall>> GetHallById(int hallId)
        {
            return await unitOfWork.RepositoryHall.GetHallWithSeatsByHallId(hallId);
        }


        [HttpPost("add")]
        public async Task<ActionResult> AddHall(Hall hall)
        {
            Hall hall1 = new Hall
            {
                Name = hall.Name,
                Capacity = hall.Capacity,
            };
            if (hall1.Capacity > 0)
            {
                hall1.Seats = new List<Seat>();
                for (int i = 0; i < hall1.Capacity; i++)
                {
                    Seat seat = new Seat
                    {
                        Id = i +1,
                        Row = i / 10 + 1,
                        SeatNumber = i + 1
                    };
                    hall1.Seats.Add(seat);
                }
            }
            unitOfWork.RepositoryHall.Save(hall1);
            if (await unitOfWork.Complete())
            {
                return Ok(hall1.Id);
            } 
            return BadRequest();
        }
    }
}
