using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Bookings.Queries
{
    public class BookingPlacesListVM
    {
        public IList<GetBookingPlacesVM> Places { get; set; }
    }
}
