using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Bookings.Queries
{
    public class BookingPlacesListVM : IMapWith<Seance>
    {
        public string CinemaHallName { get; set; }
        public string FilmName { get; set; }

        public int NumOfRow { get; set; }
        public int NumOfPlacesInRow { get; set; }

        public IList<GetBookingPlacesVM> Places { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, BookingPlacesListVM>();
        }
    }
}
