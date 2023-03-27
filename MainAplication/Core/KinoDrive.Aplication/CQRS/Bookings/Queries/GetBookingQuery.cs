﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Bookings.Queries
{
    public class GetBookingQuery : IRequest<BookingPlacesListVM>
    {
        public int SeanceId { get; set; }
    }
}
