using CinemaAPI.Entities;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class GenreController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Genre>>> GetAllGenre()
        {
            return await unitOfWork.RepositoryGenre.GetAll();
        }
    }
}
