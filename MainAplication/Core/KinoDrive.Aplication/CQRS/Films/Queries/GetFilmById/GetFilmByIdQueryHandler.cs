using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Common.LocalHostUrls;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmById
{
    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, FilmDetailInfo>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper; 

        public GetFilmByIdQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FilmDetailInfo> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            var filmDetail = await _context.Films
                .ProjectTo<FilmDetailInfo>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(film => film.Id == request.Id);

            if (filmDetail == null)
                throw new NotFoundException("FilmDetailInfo", request.Id);

            return filmDetail;
        }
    }
}
