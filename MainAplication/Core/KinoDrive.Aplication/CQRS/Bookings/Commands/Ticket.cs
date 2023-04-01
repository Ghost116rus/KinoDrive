using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Bookings.Commands
{
    public class Ticket
    {
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public int TicketCost { get; set; }
    }
}
