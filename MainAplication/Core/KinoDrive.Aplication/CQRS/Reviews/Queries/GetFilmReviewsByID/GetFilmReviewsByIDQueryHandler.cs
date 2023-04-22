using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Queries.GetFilmReviewsByID
{
    // Сортировка по дате, сначала более поздние
    public class GetFilmReviewsByIDQueryHandler
        : IRequestHandler<GetFilmReviewsByIDQuery, FilmReviewsListVM>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetFilmReviewsByIDQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FilmReviewsListVM> Handle(GetFilmReviewsByIDQuery request,
            CancellationToken cancellationToken)
        {
            var reviewList = await _context.Reviews
                .Where(r => r.FilmId == request.FilmId)
                .OrderByDescending(r => r.ChangeDate)
                .ProjectTo<ReviewLookUpDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            ReviewLookUpDTO userReview = null;

            if (reviewList is not null && request.UserId is not null)
            {
                userReview = reviewList.Find(x => x.UserId == int.Parse(request.UserId));

                if (userReview is not null)
                {
                    reviewList.Remove(userReview);
                }
            }

            return new FilmReviewsListVM { ReviewWRatingArray = reviewList, UserReview = userReview };
        }

    }
}
