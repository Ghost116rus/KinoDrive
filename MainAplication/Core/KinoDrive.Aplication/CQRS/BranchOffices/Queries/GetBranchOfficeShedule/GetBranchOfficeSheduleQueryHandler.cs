using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var DatesWFilms = new Dictionary<string, IList<FilmsForSheduleVM>>();
            var FilmsWSessions = new Dictionary<int, IList<SeanceForBranchOfficeSheduleVm>>();

            foreach(var seance in seances)
            {
                var date = seance.SeanceStartTime.Date.ToString().Split()[0];

                if(!DatesWFilms.ContainsKey(date))
                {
                    DatesWFilms.Add(date, new List<FilmsForSheduleVM>());
                    sessionShedule.Add(new DatesForSheduleVM { Date = date, Films = DatesWFilms[date] });
                }

                if(!DatesWFilms[date].Contains(seance.Film.Id))
                {

                }

                sessions[date].Add(mapper.Map<SeanceForBranchOfficeSheduleVm>(seance));
            }

            return new BranchOfficeSheduleVm { SessionShedule = sessionShedule };
        }
    }
}
