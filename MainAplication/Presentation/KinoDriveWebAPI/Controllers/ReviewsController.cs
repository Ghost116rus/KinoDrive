using KinoDrive.Aplication.CQRS.Reviews.Commands;
using KinoDrive.Aplication.CQRS.Reviews.Commands.AddNewReview;
using KinoDrive.Aplication.CQRS.Reviews.Commands.ChangeReview;
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
    public class ReviewsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> MakeReview([FromBody] ReviewDTO review)
        {
            var command = new AddNewReviewCommand()
            {
                UserId = int.Parse(base.GetUserId()),
                FilmId = review.FilmId,
                Description = review.Description
            };
            await Mediator.Send(command);

            return Created($"{command.UserId}", command.UserId);

        }

        [HttpPut]
        public async Task<IActionResult> ChangeReview([FromBody] ReviewDTO review)
        {
            var command = new ChangeReviewCommand()
            {
                UserId = int.Parse(base.GetUserId()),
                FilmId = review.FilmId,
                Description = review.Description
            };
            await Mediator.Send(command);

            return NoContent();

        }
    }
}
