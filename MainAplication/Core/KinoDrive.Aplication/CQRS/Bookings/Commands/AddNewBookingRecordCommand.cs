using MediatR;


namespace KinoDrive.Aplication.CQRS.Bookings.Commands
{
    public class AddNewBookingRecordCommand : IRequest
    {
        public int SeanceId { get; set; }
        public int UserId { get; set; }

        public IList<Ticket> Tickets { get; set; }
    }
}
