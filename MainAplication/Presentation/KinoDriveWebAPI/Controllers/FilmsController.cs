using AutoMapper;
using KinoDrive.Aplication.CQRS.Films.Commands.ChangeActivity;
using KinoDrive.Aplication.CQRS.Films.Commands.CreateFilm;
using KinoDrive.Aplication.CQRS.Films.Commands.UpdateFilm;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmById;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class FilmsController : BaseController
    {
        private readonly IMapper _mapper;

        public FilmsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ActiveFilmListVM>> GetActiveFilms()
        {
            var query = new GetActiveFilmListQuery();

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<FilmDetailVM>> GetFilmByIdAndCity(int id, string city)
        {
            var query = new GetFilmDetailQuery() { Id = id, City = city };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<FilmDetailVM>> GetFilmById(int id)
        {
            var query = new GetFilmByIdQuery() { Id = id};
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewFilm([FromBody] CreateFilmCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"{result}", result);
        }


        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateFilm([FromBody] UpdateFilmCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> ChangeActivity(int filmId, bool isActive)
        {
            var command = new ChangeActivityCommand() { FilmId = filmId, IsActive = isActive };

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
