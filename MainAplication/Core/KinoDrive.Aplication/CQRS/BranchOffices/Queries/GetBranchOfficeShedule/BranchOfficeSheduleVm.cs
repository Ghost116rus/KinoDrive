using KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{
    public class DatesForSheduleVM
    {
        public string Date { get; set; }
        public IList<BranchOfficesForFilmVM> Theaters { get; set; } = new List<BranchOfficesForFilmVM>();

    }

    public class BranchOfficeSheduleVm
    {

    }
}
