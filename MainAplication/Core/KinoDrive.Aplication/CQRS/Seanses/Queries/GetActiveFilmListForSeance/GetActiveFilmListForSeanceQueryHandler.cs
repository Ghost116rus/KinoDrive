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

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetActiveFilmListForSeance
{
    public class GetActiveFilmListForSeanceQueryHandler : IRequestHandler<GetActiveFilmListForSeanceQuery, List<ActiveFilmLoockupDTO>>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetActiveFilmListForSeanceQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ActiveFilmLoockupDTO>> Handle(GetActiveFilmListForSeanceQuery request, CancellationToken cancellationToken)
        {
            var filmList = await _context.Films.Where(x => x.isActive == true)
                .ProjectTo<ActiveFilmLoockupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return filmList;
        }
    }
}
