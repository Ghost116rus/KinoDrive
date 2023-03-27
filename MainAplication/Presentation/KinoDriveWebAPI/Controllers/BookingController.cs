using KinoDrive.Aplication.CQRS.Bookings.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    public class BookingController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<BookingPlacesListVM>> GetBookingPlaces(int seanceId)
        {
            var query = new GetBookingQuery() { SeanceId = seanceId };
            var result = await Mediator.Send(query);
            
            return Ok(result);
        }
    }
}
