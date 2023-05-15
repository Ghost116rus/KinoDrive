using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetAllFilmList
{
    public class GetAllFilmListQueryHandler : IRequestHandler<GetAllFilmListQuery, List<FilmDetailInfo>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetAllFilmListQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FilmDetailInfo>> Handle(GetAllFilmListQuery request, CancellationToken cancellationToken)
        {
            var filmList = await _context.Films
                .ProjectTo<FilmDetailInfo>(_mapper.ConfigurationProvider)
                .OrderByDescending(x=> x.isActive).ToListAsync();

            return filmList;
        }
    }
}
