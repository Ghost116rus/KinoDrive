using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int SeanceId { get; set; }
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Seance Seance { get; set; }
    }
}
