using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmDetail
{
    public class DatesForFilmVM
    {
        public string Date { get; set; }
        public IList<BranchOfficesForFilmVM>? Theaters { get; set; } = new List<BranchOfficesForFilmVM>();

    }

    public class BranchOfficesForFilmVM
    {
        public string Name { get; set; }
        public IList<SeancesForFilmVm> Seances { get; set; } = new List<SeancesForFilmVm>();
    }

    public class FilmDetailVM
    {
        public FilmDetailInfo Info { get; set; }

        public IList<DatesForFilmVM> SessionSchedule { get; set; }


    }
}
