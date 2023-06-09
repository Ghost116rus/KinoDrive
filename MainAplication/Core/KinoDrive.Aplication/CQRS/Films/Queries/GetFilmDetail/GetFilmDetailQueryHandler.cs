﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoDrive.Aplication.Common.Exceptions;
using KinoDrive.Aplication.Common.LocalHostUrls;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


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
            
            if (filmDetail == null)
                throw new NotFoundException("FilmDetailInfo", request.Id);

            var images = await _context.FilmImages
                .Where(i => i.FilmId == filmDetail.Id).ToListAsync();

            if (images is not null)
            {
                foreach (var img in images)
                {
                    img.UrlForFile = LocalHostUrlForMedia.Url + img.UrlForFile;
                    filmDetail.ImagesUrls.Add(img.UrlForFile);
                }
            }


            var seances = await _context.Seances
                .Where(s => s.FilmId == request.Id)
                 .Include(s => s.CinemaHall)
                    .ThenInclude(ch => ch.Office)
                    .Where(bh => bh.CinemaHall.Office.City == request.City && bh.SeanceStartTime >= DateTime.Now.AddHours(-2))
                    .OrderBy(s => s.SeanceStartTime).ThenBy(s => s.CinemaHall.Office.Name)
                    .ProjectTo<SeancesForFilmList>(_mapper.ConfigurationProvider)
                    .ToListAsync();



            var sessionSchedule = new List<DatesForFilmVM>();
            var sessions = new Dictionary<string, Dictionary<string, IList<SeancesForFilmVm>>>();

            foreach (var seance in seances)
            {
                var date = seance.SeanceStartTime.Date.ToString().Split()[0];
                var office = seance.BranchOfficeName;

                if (!sessions.ContainsKey(date))
                {
                    sessions.Add(date, new Dictionary<string, IList<SeancesForFilmVm>>());
                    sessionSchedule.Add(new DatesForFilmVM { Date = date });
                }

                if (!sessions[date].ContainsKey(office))
                {
                    sessions[date].Add(office, new List<SeancesForFilmVm>());
                    sessionSchedule.Find(x => x.Date == date)
                        .Theaters.Add(new BranchOfficesForFilmVM() { Name = office, Seances = sessions[date][office] });
                }

                sessions[date][office].Add(_mapper.Map<SeancesForFilmVm>(seance));

            }


            return new FilmDetailVM()
            {
                Info = filmDetail,
                SessionSchedule = sessionSchedule
            };                
        }
    }
}
