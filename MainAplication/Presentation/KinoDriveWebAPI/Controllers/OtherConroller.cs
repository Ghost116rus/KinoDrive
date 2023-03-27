using KinoDrive.Aplication.CQRS.Other.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    public class OtherConroller : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CityListVm>> GetCities()
        {
            var query = new GetCitiesQuery();

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
