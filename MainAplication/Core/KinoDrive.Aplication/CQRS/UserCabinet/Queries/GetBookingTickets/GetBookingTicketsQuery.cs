using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetBookingTickets
{
    public class GetBookingTicketsQuery : IRequest<BookingTicketsVm>
    {
        public int UserId { get; set; }
    }
}
