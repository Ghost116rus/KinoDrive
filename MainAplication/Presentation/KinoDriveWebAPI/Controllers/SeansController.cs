using KinoDrive.Aplication.CQRS.Films.Commands.CreateFilm;
using KinoDrive.Aplication.CQRS.Seanses.Commands.CreateNewShedule;
using KinoDrive.Aplication.CQRS.Seanses.Queries.GetSeanceDetailInfo;
using KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek;
using KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimeTableHard;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<ActionResult<TimetableVM>> GetTimeTableForWeek(int branchOffcieId)
        {
            var query = new GetTimetableForWeekQuery { BranchOfficeId = branchOffcieId };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MakeShedule([FromBody] MakeSheduleCommand command)
        {
            await Mediator.Send(command);

            return Created("200", 200);
        }

        [HttpGet]
        public async Task<ActionResult<TableVM>> GetHardTable(int branchOffcieId)
        {
            var query = new GetTimeTableHardQuery { BranchOfficeId = branchOffcieId };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}
