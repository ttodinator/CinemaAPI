using CinemaAPI.Entities;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class ActorController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public ActorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Actor>>> GetAllDirector()
        {
            return await unitOfWork.RepositoryActor.GetAll();
        }
    }
}
