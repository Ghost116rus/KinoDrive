using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetBookingTickets
{
    public class TicketVm : IMapWith<Booking>
    {
        public int SeanceId { get; set; }
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public int TicketCost { get; set; }

        public string FilmName { get; set; }
        public DateTime SeanceStartTime { get; set; }
        public int CinemaHallName { get; set; }
        public string BranchOfficeName { get; set; }
        public string BranchOfficeAdress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Booking, TicketVm>()
                .ForMember(t => t.SeanceStartTime,
                    opt => opt.MapFrom(b => b.Seance.SeanceStartTime))
                .ForMember(t => t.CinemaHallName,
                    opt => opt.MapFrom(b => b.Seance.CinemaHall.Name))
                .ForMember(t => t.BranchOfficeName,
                    opt => opt.MapFrom(b => b.Seance.CinemaHall.Office.Name))
                .ForMember(t => t.BranchOfficeAdress,
                    opt => opt.MapFrom(b => b.Seance.CinemaHall.Office.Adress));
        }
    }



    public class BookingTicketsVm
    {
        public IList<TicketVm> Past { get; set; }
        public IList<TicketVm> Future { get; set; }

    }
}
