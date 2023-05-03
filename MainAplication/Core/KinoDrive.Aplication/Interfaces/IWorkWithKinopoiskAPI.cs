using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.Interfaces
{
    public interface IKinopoiskAPI
    {
        Dictionary<string, float?> GetRatings(string urlForFilm);
    }
}
