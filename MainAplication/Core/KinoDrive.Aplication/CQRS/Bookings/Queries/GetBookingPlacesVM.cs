﻿using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Bookings.Queries
{
    public class GetBookingPlacesVM : IMapWith<Booking>
    {
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, GetBookingPlacesVM>();
        }
    }
}
