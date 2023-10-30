using CinemaAPI.DTOs;
using CinemaAPI.Entities;
using CinemaAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    public class MovieController : BaseApiController
    {
        IUnitOfWork unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("get-by-params")]
        public async Task<ActionResult<List<Movie>>> GetByParams(Movie movie)
        {
            return await unitOfWork.RepositoryMovie.GetBySearchParams(movie);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Movie>>> GetAllGenre()
        {
            return await unitOfWork.RepositoryMovie.GetAll();
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Movie>> GetMovie(string id)
        {
            int movieId = Convert.ToInt32(id);
            return await unitOfWork.RepositoryMovie.GetMovieById(movieId);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddMovie(AddMovieDto movieDto)
        {
            Movie movie = new Movie
            {
                Name = movieDto.Name,
                Description = movieDto.Description,
                GenreId = movieDto.GenreId,
                DirectorId = movieDto.DirectorId,
                ReleaseDate = movieDto.ReleaseDate,
            };
            if (movieDto.Roles != null && movieDto.Roles.Count > 0)
            {
                movie.Roles = new List<Role>();
                foreach (Role role in movieDto.Roles)
                {
                    if (role != null)
                    {
                        Role role1 = new Role
                        {
                            Id = role.Id,
                            MainRole = role.MainRole,
                            ActorId = role.ActorId,
                            RoleName = role.RoleName,
                        };
                        movie.Roles.Add(role1);
                    }
                }
            }
            unitOfWork.RepositoryMovie.Save(movie);
            if (await unitOfWork.Complete()) return Ok();
            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateMovie(UpdateMovieDto dto)
        {
            Movie existingMovie = await unitOfWork.RepositoryMovie.GetMovieById(dto.Id);
            existingMovie.Name = dto.Name;
            existingMovie.Description = dto.Description;
            existingMovie.ReleaseDate = dto.ReleaseDate;
            existingMovie.GenreId = dto.GenreId;
            existingMovie.DirectorId = dto.DirectorId;
            //movie.Roles = dto.Roles;
            //unitOfWork.dataContext.Entry(existingMovie).CurrentValues.SetValues(dto);

            int[] beforeDeleteion;
            int[] afterDeletion;


            if (existingMovie.Roles != null && existingMovie.Roles.Count > 0)
            {
                beforeDeleteion = new int[existingMovie.Roles.Count];
                for (int i = 0; i < existingMovie.Roles.Count; i++)
                {
                    beforeDeleteion[i] = (int)existingMovie.Roles[i].Id;
                }

                if (dto.Roles != null && dto.Roles.Count > 0)
                {
                    afterDeletion = new int[dto.Roles.Count];
                    for (int i = 0; i < dto.Roles.Count; i++)
                    {
                        afterDeletion[i] = (int)dto.Roles[i].Id;
                    }

                    if (beforeDeleteion != null && beforeDeleteion.Length > 0)
                    {
                        var deletedIds = beforeDeleteion.Except(afterDeletion);
                        foreach (int id in deletedIds)
                        {
                            Role role = unitOfWork.dataContext.Role.FirstOrDefault(r => r.Id == id);
                            unitOfWork.dataContext.Role.Remove(role);
                        }
                    }
                }
            }


            foreach (var role in dto.Roles)
            {
                var existingRole = existingMovie.Roles
                    .FirstOrDefault(p => p.Id == role.Id);

                if (existingRole == null)
                {
                    existingMovie.Roles.Add(role);
                }
                else
                {
                    unitOfWork.dataContext.Entry(existingRole).CurrentValues.SetValues(role);
                }
            }

            //unitOfWork.RepositoryMovie.Update(existingMovie);
            unitOfWork.dataContext.SaveChanges(); return Ok();
            return BadRequest();

        }
    }
}
