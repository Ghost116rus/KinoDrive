using KinoDrive.Aplication.Common.AnotherAPI;
using KinoDrive.Aplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Commands.CreateFilm
{
    public class CreateFilmCommandHanlder : IRequestHandler<CreateFilmCommand, int> 
    {
        private readonly IKinopoiskAPI _kinopoiskAPI;
        private readonly IKinoDriveDbContext _context;

        public CreateFilmCommandHanlder(IKinopoiskAPI kinopoiskAPI, IKinoDriveDbContext context)
        {
            _kinopoiskAPI = kinopoiskAPI;
            _context = context;
        }

        public async Task<int> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            _kinopoiskAPI.GetRatings("https://rating.kinopoisk.ru/1267348.xml.");
            await Task.Delay(500);

            return 1;
        }
    }
}
