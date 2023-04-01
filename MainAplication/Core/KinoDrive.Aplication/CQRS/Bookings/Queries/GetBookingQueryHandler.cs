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

namespace KinoDrive.Aplication.CQRS.Bookings.Queries
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingPlacesListVM>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetBookingQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingPlacesListVM> Handle(GetBookingQuery request,
            CancellationToken cancellationToken)
        {
            var bookingPlacesListVM = await _context.Seances
                .Where(x => x.Id == request.SeanceId)
                .ProjectTo<BookingPlacesListVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (bookingPlacesListVM == null)
            {
                return null;
            }

            bookingPlacesListVM.Places = await _context.Bookings
                .Where(b => b.SeanceId == request.SeanceId)
                .ProjectTo<GetBookingPlacesVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return bookingPlacesListVM;
        }
    }
}
