using CinemaAPI.DTOs;
using CinemaAPI.Entities;
using CinemaAPI.Extensions;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class UserController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("get-user")]
        public async Task<ActionResult<UserDto>> GetUser()
        {
            var userId = User.GetUserId();

            AppUser user = await unitOfWork.RepositoryUser.GetUser(userId);
            return new UserDto
            {
                CellphoneNumber = user.CellphoneNumber,
                UserEmail = user.UserEmail,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                DateOfBirth = user.DateOfBirth
            };
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateProfile(EditUserDto dto)
        {
            var userId = User.GetUserId();
            AppUser user = await unitOfWork.RepositoryUser.GetUser(userId);
            user.UserEmail = dto.UserEmail;
            user.UserName = dto.Username;
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.CellphoneNumber = dto.CellPhoneNumber;
            user.DateOfBirth = dto.DateOfBirth;
            unitOfWork.RepositoryUser.Update(user);
            if (await unitOfWork.Complete()) return Ok();
            return BadRequest();

        }
    }
}
