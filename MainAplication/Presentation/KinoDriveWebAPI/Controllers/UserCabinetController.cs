using KinoDrive.Aplication.CQRS.UserCabinet.Commands.ChangePassword;
using KinoDrive.Aplication.CQRS.UserCabinet.Commands.ChangeUserData;
using KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetBookingTickets;
using KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetUserInfo;
using KinoDriveWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    [Authorize]
    public class UserCabinetController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult> GetUserInfo()
        {
            var query = new GetUserInfoQuery()
            {
                UserId = int.Parse(GetUserId())
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        [HttpGet]
        public async Task<ActionResult> GetBookingTickets()
        {
            var query = new GetBookingTicketsQuery()
            {
                UserId = int.Parse(GetUserId())
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPut]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var query = new ChangePasswordCommand()
            {
                UserId = int.Parse(GetUserId()),
                OldPassword = changePasswordDTO.OldPassword,
                NewPassword = changePasswordDTO.NewPassword
            };
            await Mediator.Send(query);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> ChangeUserData([FromBody] ChangeUserDataDTO changeUserDataDTO)
        {
            var query = new ChangeUserDataCommand()
            {
                UserId = int.Parse(GetUserId()),
                LastName = changeUserDataDTO.LastName,
                FirstName = changeUserDataDTO.FirstName,
                NickName = changeUserDataDTO.NickName,
                Email = changeUserDataDTO.Email
            };
            await Mediator.Send(query);

            return NoContent();
        }
    }
}
