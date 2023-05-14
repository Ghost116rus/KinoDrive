using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Common.LocalHostUrls;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmList
{
    public class GetActiveFilmListQueryHandler
        : IRequestHandler<GetActiveFilmListQuery, ActiveFilmListVM>
    {
        private readonly IKinoDriveDbContext kinoDriveDbContext;
        private readonly IMapper mapper;

        public GetActiveFilmListQueryHandler(IKinoDriveDbContext kinoDriveDbContext, IMapper mapper)
        {
            this.kinoDriveDbContext = kinoDriveDbContext;
            this.mapper = mapper;
        }

        public async Task<ActiveFilmListVM> Handle(GetActiveFilmListQuery request,
            CancellationToken cancellationToken)
        {
            var activeFilmsList = await kinoDriveDbContext.Films
                .Where(film => film.isActive == request.isActive)
                .ProjectTo<ActiveFilmLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if(activeFilmsList.Count == 0)
                throw new NotFoundException("GetActiveFilmList", -1);

            return new ActiveFilmListVM { FilmList = activeFilmsList };
        }
    }
}
