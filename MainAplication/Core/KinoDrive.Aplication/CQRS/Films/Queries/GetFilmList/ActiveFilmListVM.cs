using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Films.Queries.GetFilmList
{
    public class ActiveFilmListVM
    {
        public IList<ActiveFilmLookupDto> FilmList { get; set; }
    }
}
