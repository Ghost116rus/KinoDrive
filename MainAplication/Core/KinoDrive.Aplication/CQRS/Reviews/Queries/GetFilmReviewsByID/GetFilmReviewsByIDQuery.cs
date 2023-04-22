using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Queries.GetFilmReviewsByID
{
    public class GetFilmReviewsByIDQuery : IRequest<FilmReviewsListVM>
    {
        public string? UserId { get; set; }
        public int FilmId { get; set; }

    }
}
