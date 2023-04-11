using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.UserCabinet.Queries.GetBookingTickets
{
    public class GetBookingTicketsQueryHandler 
        : IRequestHandler<GetBookingTicketsQuery, BookingTicketsVm>
    {
        private readonly IMapper _mapper;
        private readonly IKinoDriveDbContext _kinoDriveDbContext;

        public GetBookingTicketsQueryHandler(IMapper mapper, IKinoDriveDbContext kinoDriveDbContext)
        {
            _mapper = mapper;
            _kinoDriveDbContext = kinoDriveDbContext;
        }

        public async Task<BookingTicketsVm> Handle(GetBookingTicketsQuery request,
            CancellationToken cancellationToken)
        {
            var past = _kinoDriveDbContext.Bookings
                .Where(b => b.UserId == request.UserId && b.Seance.SeanceStartTime > DateTime.Now)
                .ProjectTo<TicketVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var future = _kinoDriveDbContext.Bookings
                .Where(b => b.UserId == request.UserId && b.Seance.SeanceStartTime <= DateTime.Now)
                .ProjectTo<TicketVm>(_mapper.ConfigurationProvider)
                .ToListAsync();

            await Task.WhenAll(past, future);

            return new BookingTicketsVm { Past = past.Result, Future = future.Result };
        }
    }
}
