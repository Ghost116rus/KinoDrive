using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class UserFilmRating
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public User User { get; set; }
        public Film Film { get; set; }
        public int Value { get; set; }
    }
}
