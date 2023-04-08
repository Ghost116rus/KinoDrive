using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficesList
{
    public class GetBranchOfficesListQueryHandlier : 
        IRequestHandler<GetBranchOfficesListQuery, ListVM>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetBranchOfficesListQueryHandlier(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListVM> Handle(GetBranchOfficesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.BranchOffices.ProjectTo<BranchOfficeVm>(_mapper.ConfigurationProvider).ToListAsync();

            if (list.Count == 0)
            {
                throw new NotFoundException("BranchOfficesList", -1);
            }

            var dict = new Dictionary<string, IList<BranchOfficeLookupForCity>>();
            var officesList = new List<CityWTheatres>();

            foreach (var office in list)
            {
                var city = office.City;

                if(!dict.ContainsKey(city))
                {
                    dict.Add(city, new List<BranchOfficeLookupForCity>());
                    officesList.Add(new CityWTheatres { City = city, Theatres = dict[city] });
                }

                dict[city].Add(_mapper.Map<BranchOfficeLookupForCity>(office));

            }

            return new ListVM { OfficeList = officesList };
        }
    }
}
