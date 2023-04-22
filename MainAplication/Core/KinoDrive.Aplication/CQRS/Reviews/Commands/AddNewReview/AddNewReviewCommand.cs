using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands.AddNewReview
{
    public class AddNewReviewCommand : IRequest
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string? Description { get; set; }
        public int Value { get; set; }
    }
}
