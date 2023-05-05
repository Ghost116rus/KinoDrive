using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice
{
    public class CreateBranchOfficeCommandHandlier
                : IRequestHandler<CreateBranchOfficeCommand, int>
    {
        private readonly IKinoDriveDbContext _context;

        public CreateBranchOfficeCommandHandlier(IKinoDriveDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBranchOfficeCommand request,
            CancellationToken cancellationToken)
        {
            var branch = new BranchOffice()
            {
                Name = request.Name,
                Email = request.Email,
                MobilePhone = request.MobilePhone,
                Description = request.Description,

                StartWorkTime = request.StartWorkTime,
                EndWorkTime = request.EndWorkTime,

                City = request.City,
                Adress = request.Adress,

                Longitude = request.Longitude,
                Latitude = request.Latitude
            };

            await _context.BranchOffices.AddAsync(branch, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            var cinemaHallNumber = 1;
            foreach (var cinemaHall in request.CinemaHallsList)
            {
                var cinema = new CinemaHall()
                {
                    Name = cinemaHallNumber++,
                    Type = cinemaHall.Type,
                    OfficeId = branch.Id,
                    NumOfRow = cinemaHall.NumOfRow,
                    NumOfPlacesInRow = cinemaHall.NumOfPlacesInRow,
                };

                await _context.CinemaHalls.AddAsync(cinema, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return branch.Id;
        }
    }
}
