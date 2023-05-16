using KinoDrive.Aplication.CQRS.Managers.Commands.DeleteManager;
using KinoDrive.Aplication.CQRS.Managers.Commands.UpdateManager;
using KinoDrive.Aplication.CQRS.Managers.Queries;
using KinoDrive.Aplication.CQRS.Operator.Commands.CreateNewOperator;
using KinoDrive.Aplication.CQRS.Operator.Commands.DeleteOperator;
using KinoDrive.Aplication.CQRS.Operator.Commands.UpdateOperator;
using KinoDrive.Aplication.CQRS.Operator.Queries;
using KinoDrive.Aplication.CQRS.Operator.Queries.GetOperator;
using KinoDrive.Aplication.CQRS.Operator.Queries.GetOperatorList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class OperatorController : BaseController
    {

        [HttpGet("{operatorId}")]
        public async Task<ActionResult<List<OperatorVm>>> GetOperator(int operatorId)
        {
            var vm = await Mediator.Send(new GetOperatorQuery() { Id = operatorId});

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<List<OperatorVm>>> GetOperatorsList()
        {
            var vm = await Mediator.Send(new GetOperatorListQuery());

            return Ok(vm);
        }



        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewOperatorCommand command)
        {
            var id = await Mediator.Send(command);

            return Created("Manager", id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperatorCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("operatorId")]
        public async Task<ActionResult<ManagerVm>> DeleteOperator(int operatorId)
        {
            var command = new DeleteOperatorCommand { OperatorId = operatorId };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
