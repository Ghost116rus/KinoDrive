using KinoDrive.Aplication.CQRS.Seanses.Queries.GetSeanceDetailInfo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Controllers
{
    public class SeansController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SeanceDetailInfoVm>> GetSeanceDetailInfo(int seanceId)
        {
            var query = new GetSeanceDetailInfoQuery { SeanceId = seanceId };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
