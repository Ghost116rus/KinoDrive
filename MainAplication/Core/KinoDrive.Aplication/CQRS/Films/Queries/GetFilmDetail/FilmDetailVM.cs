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
    public class FilmDetailVM
    {
        public FilmDetailInfo Info { get; set; }

        public Dictionary<string, Dictionary<string, IList<SeancesForFilmVm>>>? SessionSchedule { get; set; }


    }
}
