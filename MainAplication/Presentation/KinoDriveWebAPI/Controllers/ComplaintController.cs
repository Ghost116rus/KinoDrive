using KinoDrive.Aplication.CQRS.Complaints.Commands.CreateComplaint;
using KinoDrive.Aplication.CQRS.Operator.Queries.GetOperator;
using KinoDrive.Aplication.CQRS.Operator.Queries.GetOperatorList;
using KinoDrive.Aplication.CQRS.Operator.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinoDrive.Aplication.CQRS.Complaints.Common;
using KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsWithAnswer;
using KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsWithoutAnswer;
using KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaints;
using KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsByBranchOffice;
using KinoDrive.Aplication.CQRS.Complaints.Queries.GetAllComplaintsByUser;

namespace KinoDriveWebAPI.Controllers
{
    [Authorize]
    public class ComplaintController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateComplaint(string text, int? brId)
        {
            var command = new CreateComplaintCommand()
            {
                UserId = int.Parse(GetUserId()),
                Description = text,
                BranchOfficeId = brId,
            };

            var id = await Mediator.Send(command);

            return Created("Complaint is succesful created", id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<List<ComplaintVM>>> GetAllComplaints()
        {
            var vm = await Mediator.Send(new GetAllComplaintsQuery());

            return Ok(vm);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<ActionResult<List<ComplaintVM>>> GetAllComplaintsByBranchOffice()
        {
            var query = new GetAllComplaintsByBranchOfficeQuery()
            {
                ManagerId = int.Parse(GetUserId()),
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }



        [HttpGet]
        public async Task<ActionResult<List<ComplaintVM>>> GetAllComplaintsByUser()
        {
            var query = new GetAllComplaintsByUserQuery()
            {
                UserId = int.Parse(GetUserId()),
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        [Authorize(Roles = "Administrator, Operator")]
        [HttpGet]
        public async Task<ActionResult<List<ComplaintVM>>> GetComplaintsListWithAnswer()
        {
            var vm = await Mediator.Send(new GetAllComplaintsWithAnswerQuery());

            return Ok(vm);
        }

        [Authorize(Roles = "Administrator, Operator")]
        [HttpGet]
        public async Task<ActionResult<List<ComplaintVM>>> GetComplaintsListWithoutAnswer()
        {
            var vm = await Mediator.Send(new GetAllComplaintsWithoutAnswerQuery());

            return Ok(vm);
        }

    }
}
