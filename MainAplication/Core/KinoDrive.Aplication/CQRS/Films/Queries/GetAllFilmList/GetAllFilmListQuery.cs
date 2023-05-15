using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetAllFilmList
{
    public class GetAllFilmListQuery : IRequest<List<FilmDetailInfo>>
    {

    }
}
