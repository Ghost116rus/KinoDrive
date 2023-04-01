using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
using MediatR;


namespace KinoDrive.Aplication.CQRS.Bookings.Commands
{
    public class AddNewBookingRecordCommandHandler 
        : IRequestHandler<AddNewBookingRecordCommand>
    {
        private readonly IKinoDriveDbContext context;

        public AddNewBookingRecordCommandHandler (IKinoDriveDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(AddNewBookingRecordCommand request,
            CancellationToken cancellationToken)
        {
            foreach (var item in request.Tickets)
            {
                var ticket = new Booking
                {
                    UserId = request.UserId,
                    SeanceId = request.SeanceId,
                    RowNumber = item.RowNumber,
                    PlaceNumber = item.PlaceNumber,
                    TicketCost = item.TicketCost
                };

                await context.Bookings.AddAsync(ticket);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

    }
}
