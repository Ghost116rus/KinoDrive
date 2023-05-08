using KinoDrive.Aplication.CQRS.Films.Commands.CreateFilm;
using KinoDrive.Aplication.CQRS.FilmsStaff.Commands.CreateFilmsActor;
using KinoDrive.Aplication.CQRS.FilmsStaff.Commands.DeleteFilmActor;
using KinoDrive.Aplication.CQRS.FilmsStaff.Commands.UpdateFilmActor;
using KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetActorList;
using KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetFilmDirectorsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class FilmsStaffController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<ActorListVM>> GetAllActors()
        {
            var query = new GetActorListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost("{Name}")]
        public async Task<ActionResult<int>> CreateNewActor(string Name)
        {
            var command = new FilmsActorCreateCommand() { Name = Name };

            var result = await Mediator.Send(command);

            return Created($"{result}", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor([FromBody] UpdateFilmActorCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var command = new DeleteFilmActorCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<FilmDirectorsListVm>> GetAllFilmDirectors()
        {
            var query = new GetFilmDirectorsListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}
