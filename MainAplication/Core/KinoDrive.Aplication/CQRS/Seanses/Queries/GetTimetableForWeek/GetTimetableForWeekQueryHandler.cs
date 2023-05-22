using AutoMapper;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek
{
    public class GetTimetableForWeekQueryHandler : IRequestHandler<GetTimetableForWeekQuery, TimetableVM>
    {
        private readonly IMapper mapper;
        private readonly IKinoDriveDbContext kinoDriveDbContext;

        public GetTimetableForWeekQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
        {
            this.mapper = mapper;
            this.kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task<TimetableVM> Handle(GetTimetableForWeekQuery request, CancellationToken cancellationToken)
        {
            var timetable = new TimetableVM();

            var office = await kinoDriveDbContext.BranchOffices
                .Where(brOff => brOff.Id == request.BranchOfficeId)
                .FirstOrDefaultAsync();

            if (office == null)
            {
                throw new NotFoundException(nameof(BranchOffice), request.BranchOfficeId);
            }

            timetable.StartTime = office.StartWorkTime;
            timetable.EndTime = office.EndWorkTime;
            timetable.FullList = new List<DayVM>();
            var cinemaHalls = await kinoDriveDbContext.CinemaHalls
                .Where(hall => hall.OfficeId == request.BranchOfficeId)
                .OrderBy(hall => hall.Name)
                .ToListAsync();

            var currentDay = DateTime.Today.AddDays(1);

            for (int i = 0; i < 7; i++)
            {
                var day = new DayVM();

                day.Date = currentDay;
                day.Halls = new List<HallVM>();
                
                var currentBreakId = -1;

                foreach (var hall in cinemaHalls)
                {
                    var hallVm = new HallVM();
                    hallVm.Id = hall.Id;
                    hallVm.HallNumber = hall.Name;
                    hallVm.Seances = new List<SeanceVM>();

                    var seances = await kinoDriveDbContext.Seances
                        .Where(s => s.CinemaHallId == hall.Id && s.SeanceStartTime.Day == currentDay.Day)
                        .OrderBy(s => s.SeanceStartTime)
                        .Include(s => s.Film)
                        .ToListAsync();

                    foreach (var seance in seances)
                    {
                        var seanceVM = new SeanceVM();
                        seanceVM.Id = seance.Id;
                        seanceVM.Cost = seance.BasicCost;
                        seanceVM.Film = mapper.Map<FilmVM>(seance.Film);
                        hallVm.Seances.Add(seanceVM);
                    }
                    
                    var insertingIndexAdding = 0;

                    for (int j = 0; j < seances.Count - 1; j++)
                    {
                        var breakTime = seances[j + 1].SeanceStartTime
                            .Subtract(seances[j].SeanceStartTime.AddMinutes(seances[j].Film.Length)).TotalMinutes;

                        if (breakTime < 5.2)
                        {
                            hallVm.Seances.Insert(j + 1 + insertingIndexAdding, new SeanceVM()
                                {
                                    Id = currentBreakId,
                                    Cost = -1,
                                    Film = new FilmVM()
                                    {
                                        Id = 0,
                                        Duration = Math.Abs((int)Math.Ceiling(breakTime / 5) * 5),
                                        Name = "Перерыв"
                                    }
                                }
                            );

                            currentBreakId--;
                            insertingIndexAdding++;

                        }
                    }

                    day.Halls.Add(hallVm);

                }

                day.MaxFreeId = currentBreakId;

                timetable.FullList.Add(day);

                currentDay = currentDay.AddDays(1);

            }

            return timetable;
        }

    }
   
}
