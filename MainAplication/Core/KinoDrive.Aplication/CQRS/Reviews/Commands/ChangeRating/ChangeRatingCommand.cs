using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Commands.ChangeRating
{
    public class ChangeRatingCommand : IRequest
    {
        public int UserID { get; set; }
        public int FilmId { get; set; }
        public int NewValue { get; set; }
    }
}
