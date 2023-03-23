using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class Film
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int Length { get; set; }

        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public IEnumerable<Seance> Seances { get; set; } = new List<Seance>();
    }
}
