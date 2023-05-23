using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetActiveFilmListForSeance
{
    public class GetActiveFilmListForSeanceQuery : IRequest<List<ActiveFilmLoockupDTO>>
    {

    }
}
