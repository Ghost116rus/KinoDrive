using KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetBookingTickets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> GetBookingTickets()
        {
            var query = new GetBookingTicketsQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
