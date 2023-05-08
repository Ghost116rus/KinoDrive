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

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetFilmDirectorsList
{
    public class GetFilmDirectorsListQueryHandler
        : IRequestHandler<GetFilmDirectorsListQuery, FilmDirectorsListVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetFilmDirectorsListQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FilmDirectorsListVm> Handle(GetFilmDirectorsListQuery request,
            CancellationToken cancellationToken)
        {
            var filmDirectorsList = await _context.FilmDirectors
                .ProjectTo<FilmDirectorsLookupDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new FilmDirectorsListVm { FilmDirectorList = filmDirectorsList };
        }

    }
}
