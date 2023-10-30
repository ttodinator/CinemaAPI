using CinemaAPI.Entities;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class DirectorController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public DirectorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Director>>> GetAllDirector()
        {
            return await unitOfWork.RepositoryDirector.GetAll();
        }
    }
}
