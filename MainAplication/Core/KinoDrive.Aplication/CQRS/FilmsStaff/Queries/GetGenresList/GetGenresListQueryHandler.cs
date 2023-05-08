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

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetGenresList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetGenresListQuery, GenreListVm>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresListQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GenreListVm> Handle(GetGenresListQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Genres.ProjectTo<GenreLookupDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GenreListVm { genres = vm };
        }

    }
}
