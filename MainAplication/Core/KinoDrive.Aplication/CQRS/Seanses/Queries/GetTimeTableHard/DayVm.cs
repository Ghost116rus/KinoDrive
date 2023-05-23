using KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimeTableHard
{
    public class DayVm
    {
        public DateTime Date { get; set; }
        public Dictionary<string, SeanceVM> Seances { get; set; } = new Dictionary<string, SeanceVM>();
        public Dictionary<string, HallVm> Halls { get; set; } = new Dictionary<string, HallVm>();
    }
}
