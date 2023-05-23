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

namespace KinoDrive.Aplication.CQRS.Seanses.Commands.CreateNewShedule
{

    public class MakeSheduleCommandHandler : IRequestHandler<MakeSheduleCommand>
    {
        private readonly IKinoDriveDbContext _context;

        public MakeSheduleCommandHandler(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task Handle(MakeSheduleCommand request, CancellationToken cancellationToken)
        {
            // Здесь может быть ваша валидация данных, есть ли такие фильмы в бд, филиалы или кинозалы

            var shedule = request.Shedule;

            var office = await _context.BranchOffices.FirstOrDefaultAsync(x => x.Id == shedule.BranchOfficeId);
            
            if (office == null) throw new NotFoundException("Филиал не найден", shedule.BranchOfficeId);


            foreach (var cinemaHall in shedule.Halls)
            {
                var currentTime = shedule.Date.Date.AddHours(office.StartWorkTime);

                var seances = cinemaHall.Seances;

                foreach (var seance in seances)
                {
                    
                    if (currentTime.AddMinutes(seance.Film.Duration) > shedule.Date.Date.AddHours(office.EndWorkTime))
                    {
                        break;
                    }

                    if (seance.Film.Id != -1)
                    {
                        Seance seanceEntity;

                        if (seance.Id == -1)
                        {
                            seanceEntity = new Seance()
                            {
                                FilmId = seance.Film.Id,
                                Type = seance.Type,
                                SeanceStartTime = currentTime,
                                BasicCost = seance.cost,
                                CinemaHallId = cinemaHall.Id
                            };

                            await _context.Seances.AddAsync(seanceEntity);
                        }
                        else
                        {
                            seanceEntity = await _context.Seances.FirstOrDefaultAsync(x => x.Id == seance.Id);

                            if (seanceEntity is null)
                            {
                                throw new NotFoundException("Сеанс не найден", seance.Id);
                            }

                            seanceEntity.SeanceStartTime = currentTime;
                            seanceEntity.BasicCost = seance.cost;
                            seanceEntity.CinemaHallId = cinemaHall.Id;

                            // Здесь можно подключить логику уведомления об изменении расписания!
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    currentTime = currentTime.AddMinutes(seance.Film.Duration);
                }
            }

            foreach (var seance in request.Basket)
            {
                var seanceEntity = await _context.Seances.FirstOrDefaultAsync(x => x.Id == seance.Id);

                if (seanceEntity is not null)
                {
                    _context.Seances.Remove(seanceEntity);
                }

            }

            await _context.SaveChangesAsync(cancellationToken);




        }
    }
}
