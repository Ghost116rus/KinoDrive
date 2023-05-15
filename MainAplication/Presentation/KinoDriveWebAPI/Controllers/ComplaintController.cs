using KinoDrive.Aplication.CQRS.Complaints.Commands.CreateComplaint;
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
    }
}
