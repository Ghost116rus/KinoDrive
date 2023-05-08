using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmById
{
    public class GetFilmByIdQuery : IRequest<FilmDetailInfo>
    {
        public int Id { get; set; } 
    }
}
