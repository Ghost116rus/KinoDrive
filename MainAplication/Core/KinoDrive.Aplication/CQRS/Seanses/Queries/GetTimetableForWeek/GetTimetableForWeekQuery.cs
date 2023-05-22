using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek
{
    public class GetTimetableForWeekQuery : IRequest<TimetableVM>
    {
        public int BranchOfficeId { get; set; }
    }
}
