using KinoDrive.Aplication.CQRS.Auth.Commands.Register;
using KinoDrive.Aplication.CQRS.Auth.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Registrate([FromBody] RegisterCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginQuery command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
