using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Commands.UpdateBranchOffice
{
    public class CinemaHallLookupDTOForUpdate
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int NumOfRow { get; set; }
        public int NumOfPlacesInRow { get; set; }

        public bool IsChanged { get; set; }
    }
}
