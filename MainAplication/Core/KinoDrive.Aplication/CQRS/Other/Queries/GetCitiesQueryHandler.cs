using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Other.Queries
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, CityListVm>
    {
        private readonly IMapper mapper;
        private readonly IKinoDriveDbContext context;

        public GetCitiesQueryHandler(IMapper mapper, IKinoDriveDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<CityListVm> Handle(GetCitiesQuery request,
            CancellationToken cancellationToken)
        {
            var list = await context.BranchOffices
                .Select(br => br.City)
                .Distinct()
                .ToListAsync();

            return new CityListVm { Cities = list };
        }
    }
}
