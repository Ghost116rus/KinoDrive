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

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{

    public class GetBranchOfficeSheduleQueryHandler :
        IRequestHandler<GetBranchOfficeSheduleQuery, BranchOfficeSheduleVm>
    {
        private readonly IMapper mapper;
        private readonly IKinoDriveDbContext kinoDriveDbContext;

        public GetBranchOfficeSheduleQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
        {
            this.mapper = mapper;
            this.kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task<BranchOfficeSheduleVm> Handle(GetBranchOfficeSheduleQuery request,
            CancellationToken cancellationToken)
        {
            var seances = await kinoDriveDbContext.Seances
                .Include(s => s.CinemaHall)
                    .ThenInclude(ch => ch.Office)
                    .Where(bf => bf.CinemaHall.Office.Id == request.BranchOfficeId && bf.SeanceStartTime >= DateTime.Now.AddHours(-2))
                    .OrderBy(s => s.SeanceStartTime)
                    .ProjectTo<SeanceForBranchOfficeSheduleList>(mapper.ConfigurationProvider)
                    .ToListAsync();

            var sessionShedule = new List<DatesForSheduleVM>();
            var sessions = new Dictionary<string, IList<SeanceForBranchOfficeSheduleVm>>();

            foreach(var seance in seances)
            {
                var date = seance.SeanceStartTime.Date.ToString().Split()[0];

                if(!sessions.ContainsKey(date))
                {
                    sessions.Add(date, new List<SeanceForBranchOfficeSheduleVm>());
                    sessionShedule.Add(new DatesForSheduleVM { Date = date, Seances = sessions[date] });
                }

                sessions[date].Add(mapper.Map<SeanceForBranchOfficeSheduleVm>(seance));
            }

            return new BranchOfficeSheduleVm { SessionShedule = sessionShedule };
        }
    }
}
