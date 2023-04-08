using AutoMapper;
using KinoDrive.Aplication.CQRS.Bookings.Commands;
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
    public class BookingController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> BookingTickets([FromBody] AddNewBookingRecordCommand command)
        {
            await Mediator.Send(command);

            return Created($"{command.UserId}", command.UserId);
        }
    }
}
