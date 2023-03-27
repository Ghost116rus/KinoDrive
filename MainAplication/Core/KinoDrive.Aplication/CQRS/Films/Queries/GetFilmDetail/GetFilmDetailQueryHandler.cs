﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class GetFilmDetailQueryHandler : 
        IRequestHandler<GetFilmDetailQuery, FilmDetailVM>
    {
        private readonly IKinoDriveDbContext _context;
        private readonly IMapper _mapper;

        public GetFilmDetailQueryHandler(IKinoDriveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FilmDetailVM> Handle(GetFilmDetailQuery request, 
            CancellationToken cancellationToken)
        {
            var filmDetail = await _context.Films
                .ProjectTo<FilmDetailVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(film => film.Id == request.Id);

            filmDetail.Seances = await _context.Seances
                .Where(s => s.FilmId == request.Id)
                 .Include(s => s.CinemaHall)
                    .ThenInclude(ch => ch.Office)
                    .Where(bh => bh.CinemaHall.Office.City == request.City && bh.SeanceStartTime.Date >= DateTime.Now.Date)
                    .OrderBy(s => s.SeanceStartTime).ThenBy(s => s.CinemaHall.Office.Name).ThenBy(s => s.CinemaHall.Name)
                    .ProjectTo<SeancesForFilmVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return filmDetail;                
        }
    }
}
