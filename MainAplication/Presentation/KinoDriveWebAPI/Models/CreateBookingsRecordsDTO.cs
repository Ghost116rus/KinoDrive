using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.CQRS.Bookings.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDriveWebAPI.Models
{
    public class CreateBookingsRecordsDTO : IMapWith<AddNewBookingRecordCommand>
    {
        public int SeanceId { get; set; }
        public int UserId { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookingsRecordsDTO, AddNewBookingRecordCommand>();
        }
    }
}
