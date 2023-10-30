using CinemaAPI.DTOs;
using CinemaAPI.Entities;
using CinemaAPI.Extensions;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class ScreeningController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public ScreeningController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddScreening(Screening screening)
        {
            if (screening == null) return BadRequest();
            Screening screening1 = new Screening
            {
                Date = screening.Date,
                HallId = screening.Hall.Id,
                MovieId = screening.Movie.Id,
                Price = screening.Price

            };
            unitOfWork.RepositoryScreening.Save(screening1);
            if (await unitOfWork.Complete()) return Ok();
            return BadRequest();
        }

        [HttpPost("get-by-params")]
        public async Task<ActionResult<List<Screening>>> GetByParams(SearchScreeningDto dto)
        {
            return await unitOfWork.RepositoryScreening.GetBySearchParams(dto);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Screening>> GetScreening(string id)
        {
            int screeningId = Convert.ToInt32(id);
            return await unitOfWork.RepositoryScreening.GetScreeningById(screeningId);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateScreening(UpdateScreeningDto dto)
        {
            var screening = await unitOfWork.RepositoryScreening.GetScreeningById(dto.Id);
            screening.Date = dto.Date;
            screening.HallId = dto.HallId;
            screening.MovieId = dto.MovieId;
            screening.Price = dto.Price;
            unitOfWork.RepositoryScreening.Update(screening);
            if (await unitOfWork.Complete()) return Ok();
            return BadRequest();

        }

        [HttpDelete("delete/{screeningId}")]
        public async Task<ActionResult> DeleteScreening(int screeningId)
        {
            var screening = await unitOfWork.RepositoryScreening.GetScreeningById(screeningId);

            unitOfWork.RepositoryScreening.DeleteScreeningById(screening);

            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Unable to delete screening");

        }
    }
}
