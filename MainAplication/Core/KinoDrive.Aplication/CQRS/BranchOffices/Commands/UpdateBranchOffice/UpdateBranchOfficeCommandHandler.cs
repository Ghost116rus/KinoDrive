using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.UpdateBranchOffice
{

    public class UpdateBranchOfficeCommandHandler : 
        IRequestHandler<UpdateBranchOfficeCommand>
    {
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public UpdateBranchOfficeCommandHandler(IKinoDriveDbContext kinoDriveDbContext)
        {
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task Handle(UpdateBranchOfficeCommand request, 
            CancellationToken cancellationToken)
        {
            var branch = await _kinoDriveDbContext.BranchOffices.Include(x => x.CinemaHalls).FirstOrDefaultAsync(br => br.Id == request.Id);

            if (branch is null)
            {
                throw new NotFoundException("BranchOffice", -1);
            }

            branch.Name = request.Name;
            branch.Email = request.Email;
            branch.MobilePhone = request.MobilePhone;
            branch.Description = request.Description;
            branch.StartWorkTime = request.StartWorkTime;
            branch.EndWorkTime = request.EndWorkTime;
            branch.City = request.City;
            branch.Adress = request.Adress;
            branch.Longitude = request.Longitude;
            branch.Latitude = request.Latitude;

            if (request.IsChangedCinemaHalls)
            {
                int cinemaHallNumber = 1;
                bool wasDeleteCinemaHall = false;

                foreach (var cinemaHall in branch.CinemaHalls)
                {
                    var cinemaHallFromFront = request.CinemaHallsList.FirstOrDefault(x => x.Id == cinemaHall.Id);

                    if (cinemaHallFromFront is null)
                    {
                        // В последствии доработать этот метод, чтобы можно было оповестить пользователей об устранении данного кинозала
                        _kinoDriveDbContext.CinemaHalls.Remove(cinemaHall);


                        wasDeleteCinemaHall = true;
                        continue;
                    }
                    request.CinemaHallsList.Remove(cinemaHallFromFront);

                    if (cinemaHallFromFront.IsChanged)
                    {
                        cinemaHall.Type = cinemaHallFromFront.Type;
                        cinemaHall.NumOfRow = cinemaHallFromFront.NumOfRow;
                        cinemaHall.NumOfPlacesInRow = cinemaHallFromFront.NumOfPlacesInRow;
                    }

                    if (wasDeleteCinemaHall)
                    {
                        cinemaHall.Name = cinemaHallNumber;
                    }

                    cinemaHallNumber++;
                }

                var newCinemaHallFromFront = request.CinemaHallsList.FirstOrDefault(x => x.Id == -1);
                while (newCinemaHallFromFront is not null)
                {
                    var cinema = new CinemaHall()
                    {
                        Name = cinemaHallNumber++,
                        Type = newCinemaHallFromFront.Type,
                        OfficeId = branch.Id,
                        NumOfRow = newCinemaHallFromFront.NumOfRow,
                        NumOfPlacesInRow = newCinemaHallFromFront.NumOfPlacesInRow,
                    };

                    await _kinoDriveDbContext.CinemaHalls.AddAsync(cinema, cancellationToken);
                    request.CinemaHallsList.Remove(newCinemaHallFromFront);

                    newCinemaHallFromFront = request.CinemaHallsList.FirstOrDefault(x => x.Id == -1);
                }
            }

            await _kinoDriveDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
