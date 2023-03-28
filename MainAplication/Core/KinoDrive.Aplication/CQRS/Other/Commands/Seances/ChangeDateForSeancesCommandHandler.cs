using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Other.Commands.Seances
{
    public class ChangeDateForSeancesCommandHandler 
        : IRequestHandler <ChangeDateForSeancesCommand>
    {
        private readonly IKinoDriveDbContext kinoDriveDbContext;
        
        public ChangeDateForSeancesCommandHandler(IKinoDriveDbContext kinoDriveDbContext)
        {
            this.kinoDriveDbContext = kinoDriveDbContext;
        }

        private DateTime ChangeDate(DateTime previous, int addDays)
        {
            DateTime now = DateTime.Today.AddDays(addDays);
            DateTime newDate = new DateTime(
                now.Year,
                now.Month,
                now.Day,
                previous.Hour,
                previous.Minute,
                previous.Second
                );

            return newDate;
        }

        public async Task Handle(ChangeDateForSeancesCommand request,
            CancellationToken cancellationToken)
        {
            Random random = new Random();
            var seanceList = await kinoDriveDbContext.Seances.ToListAsync();

            foreach (var seance in seanceList)
            {
                var kubik = random.Next(0, 3);
                seance.SeanceStartTime = ChangeDate(seance.SeanceStartTime, kubik);
            }

            await kinoDriveDbContext.SaveChangesAsync(cancellationToken);
        }


    }
}
