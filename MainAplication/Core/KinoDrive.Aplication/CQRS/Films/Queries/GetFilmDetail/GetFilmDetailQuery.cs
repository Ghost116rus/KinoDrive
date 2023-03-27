using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class GetFilmDetailQuery : IRequest<FilmDetailVM>
    {
        public int Id { get; set; }
        public string? City { get; set; }
    }
}
