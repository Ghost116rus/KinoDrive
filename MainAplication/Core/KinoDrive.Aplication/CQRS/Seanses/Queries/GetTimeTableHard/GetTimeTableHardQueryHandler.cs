using AutoMapper;
using KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek;
using KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimeTableHard;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimeTableHard
{
    public class GetTimeTableHardQueryHandler : IRequestHandler<GetTimeTableHardQuery, TableVM>
    {
        private readonly IMapper _mapper;
        private readonly IKinoDriveDbContext _context;

        public GetTimeTableHardQueryHandler(IMapper mapper, IKinoDriveDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TableVM> Handle(GetTimeTableHardQuery request, CancellationToken cancellationToken)
        {
            var table = new TableVM
            {
                StartTime = 5,
                EndTime = 5,
            };

            var table1 = new List<DayVm>();

            var day = new DayVm()
            {
                Date = DateTime.Now,
            };


            table.Table = table1;
            table1.Add(day);

            var seance = new SeanceVM() { Id = 1 };

            day.Seances.Add(seance.Id.ToString(), seance);

            return table;
        }
    }
}
