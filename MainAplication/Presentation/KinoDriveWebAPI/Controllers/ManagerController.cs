using KinoDrive.Aplication.CQRS.Managers.Commands.CreateNewManager;
using KinoDrive.Aplication.CQRS.Managers.Commands.DeleteManager;
using KinoDrive.Aplication.CQRS.Managers.Commands.UpdateManager;
using KinoDrive.Aplication.CQRS.Managers.Queries;
using KinoDrive.Aplication.CQRS.Managers.Queries.GetManager;
using KinoDrive.Aplication.CQRS.Managers.Queries.GetManagerList;
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
    public class ManagerController : BaseController
    {
        [HttpGet("{managerId}")]
        public async Task<ActionResult<ManagerVm>> GetManagerById(int managerId)
        {
            var command = new GetManagerQuery { Id = managerId };

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ManagerVm>> GetManagerList()
        {
            var command = new GetManagerListQuery();

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewManagerCommand command)
        {
            var id = await Mediator.Send(command);

            return Created("Manager", id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateManagerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("managerId")]
        public async Task<IActionResult> DeleteManagerById(int managerId)
        {
            var command = new DeleteManagerCommand { Id = managerId };

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
