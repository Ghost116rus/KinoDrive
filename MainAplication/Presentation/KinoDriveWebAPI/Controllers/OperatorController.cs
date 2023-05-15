using KinoDrive.Aplication.CQRS.Operator.Commands.CreateNewOperator;
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
    public class OperatorController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewOperatorCommand command)
        {
            var id = await Mediator.Send(command);

            return Created("Manager", id);
        }
    }
}
