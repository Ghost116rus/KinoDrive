using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek
{
    public class TimetableVM
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public IList<DayVM> FullList { get; set; }


    }
}
