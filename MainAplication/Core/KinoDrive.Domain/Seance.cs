using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class Seance
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CinemaHallId { get; set; }

        public DateTime SeanceStartTime { get; set; }

        public int BasicCost { get; set; }

        public Film Film { get; set; }
        public CinemaHall CinemaHall { get; set; }
    }
}
