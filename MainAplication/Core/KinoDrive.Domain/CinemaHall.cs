using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int NumOfRow { get; set; }
        public int NumOfPlacesInRow { get; set; }

        public int OfficeId { get; set; }
        public BranchOffice Office { get; set; }
    }
}
