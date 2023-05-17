using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Seanses.Queries.GetTimetableForWeek
{
    public class SeanceVM
    {
        public int Id { get; set; }

        public int Cost { get; set; } = -1;

        public FilmVM Film { get; set; }

    }
}
