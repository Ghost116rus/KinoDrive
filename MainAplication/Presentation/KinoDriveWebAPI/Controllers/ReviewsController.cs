using KinoDrive.Aplication.CQRS.Reviews.Commands;
using KinoDrive.Aplication.CQRS.Reviews.Commands.AddNewReview;
using KinoDrive.Aplication.CQRS.Reviews.Queries.GetFilmReviewsByID;
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
        public async Task<IActionResult> CreateOrUpdateReview([FromBody] ReviewDTO review)
        {
            var command = new AddNewReviewCommand()
            {
                UserId = int.Parse(base.GetUserId()),
                FilmId = review.FilmId,
                Value = review.Value,
                Description = review.Description
            };
            await Mediator.Send(command);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<FilmReviewsListVM>> GetReviewsForFilmById(int FilmId)
        {
            var query = new GetFilmReviewsByIDQuery
            {
                UserId = GetUserId(),
                FilmId = FilmId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}
