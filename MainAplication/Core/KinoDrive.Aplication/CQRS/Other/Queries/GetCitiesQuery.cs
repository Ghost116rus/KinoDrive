using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Other.Queries
{
    public class GetCitiesQuery : IRequest<CityListVm>
    {

    }
}
