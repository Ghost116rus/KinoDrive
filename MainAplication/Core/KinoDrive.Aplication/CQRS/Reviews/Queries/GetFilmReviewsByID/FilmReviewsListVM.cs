using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Queries.GetFilmReviewsByID
{
    public class FilmReviewsListVM
    {
        public IList<ReviewLookUpDTO> ReviewWRatingArray { get; set; }
        public ReviewLookUpDTO? UserReview { get; set; }
    }
}
