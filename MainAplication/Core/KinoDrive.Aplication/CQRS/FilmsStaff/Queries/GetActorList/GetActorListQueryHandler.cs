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

namespace KinoDrive.Aplication.CQRS.FilmsStaff.Queries.GetActorList
{
    public class GetActorListQueryHandler 
        : IRequestHandler<GetActorListQuery, ActorListVM>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetActorListQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActorListVM> Handle(GetActorListQuery request, CancellationToken cancellationToken)
        {
            var actorList = await _context.Actors.ProjectTo<ActorLookupDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new ActorListVM { actorsList = actorList };
        }

    }
}
