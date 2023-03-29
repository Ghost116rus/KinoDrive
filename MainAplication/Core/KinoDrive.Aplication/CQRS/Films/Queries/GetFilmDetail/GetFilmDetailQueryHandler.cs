﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Aplication.Interfaces;
using KinoDrive.Domain;
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
                .ProjectTo<FilmDetailInfo>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(film => film.Id == request.Id);
            
            if (filmDetail == null) return null;

            var seances = await _context.Seances
                .Where(s => s.FilmId == request.Id)
                 .Include(s => s.CinemaHall)
                    .ThenInclude(ch => ch.Office)
                    .Where(bh => bh.CinemaHall.Office.City == request.City && bh.SeanceStartTime >= DateTime.Now.AddHours(-2))
                    .OrderBy(s => s.SeanceStartTime).ThenBy(s => s.CinemaHall.Office.Name).ThenBy(s => s.CinemaHall.Name)
                    .ProjectTo<SeancesForFilmList>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            var sessionSchedule = new Dictionary<string, Dictionary<string, IList<SeancesForFilmVm>>>();

            foreach(var seance in seances)
            {
                var date = seance.SeanceStartTime.Date.ToString().Split()[0];
                var office = seance.BranchOfficeName;
                
                if (!sessionSchedule.ContainsKey(date))
                {
                    sessionSchedule.Add(date, new Dictionary<string, IList<SeancesForFilmVm>>());
                }

                if (!sessionSchedule[date].ContainsKey(office))
                {
                    sessionSchedule[date].Add(office, new List<SeancesForFilmVm>());
                }

                sessionSchedule[date][office].Add(_mapper.Map<SeancesForFilmVm>(seance));

            }
            var list = new List<DatesForFilmVM>();

            foreach (var item in sessionSchedule)
            {
                var date = new DatesForFilmVM();
                date.Date = item.Key;
                foreach (var vm in item.Value)
                {
                    var branch = new BranchOfficesForFilmVM();
                    branch.Name = vm.Key;
                    foreach (var seance in vm.Value)
                    {
                        branch.Seances.Add(seance);
                    }
                    date.Theaters.Add(branch);
                }
                list.Add(date);
            }

            return new FilmDetailVM()
            {
                Info = filmDetail,
                SessionSchedule = list
            };                
        }
    }
}
