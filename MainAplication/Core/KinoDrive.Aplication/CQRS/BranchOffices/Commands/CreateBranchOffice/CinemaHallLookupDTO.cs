using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.CreateBranchOffice
{
    public class CinemaHallLookupDTO
    {
        public int Type { get; set; }
        public int NumOfRow { get; set; }
        public int NumOfPlacesInRow { get; set; }
    }
}
