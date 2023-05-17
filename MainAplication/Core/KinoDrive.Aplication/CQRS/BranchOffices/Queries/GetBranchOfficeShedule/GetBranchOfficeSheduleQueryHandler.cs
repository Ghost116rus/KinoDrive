using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Common.LocalHostUrls;
using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            if (seances.Count == 0)
            {
                throw new NotFoundException("BranchOfficeShedule", request.BranchOfficeId);
            }

            var sessionShedule = new List<DatesForSheduleVM>();
            var shedule = new Dictionary<string, Dictionary<int, IList<SeanceForBranchOfficeSheduleVm>>>();


            foreach(var seance in seances)
            {
                var date = seance.SeanceStartTime.Date.ToString().Split()[0];
                var filmID = seance.Film.Id;

                if (!shedule.ContainsKey(date))
                {
                    shedule.Add(date, new Dictionary<int, IList<SeanceForBranchOfficeSheduleVm>>());
                    sessionShedule.Add(new DatesForSheduleVM { Date = date, Films = new List<FilmsForSheduleVM>() });
                }

                if(!shedule[date].ContainsKey(filmID))
                {
                    shedule[date].Add(filmID, new List<SeanceForBranchOfficeSheduleVm>());
                    sessionShedule.Find(x => x.Date == date)
                        .Films.Add(new FilmsForSheduleVM { Film = seance.Film, Seances = shedule[date][filmID] });                        
                }

                shedule[date][filmID].Add(mapper.Map<SeanceForBranchOfficeSheduleVm>(seance));
            }

            return new BranchOfficeSheduleVm { SessionShedule = sessionShedule };
        }
    }
}
