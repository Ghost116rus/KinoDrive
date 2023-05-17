using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek
{
    public class DayVM
    {
        public DateTime Date { get; set; }

        public IList<HallVM> Halls { get; set; }


    }
}
