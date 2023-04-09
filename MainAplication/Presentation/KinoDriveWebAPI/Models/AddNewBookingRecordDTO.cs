using KinoDrive.Aplication.CQRS.Bookings.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Models
{
    public class AddNewBookingRecordDTO
    {
        public int SeanceId { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}
