using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCore.Domain
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FilmImage>? Images { get; set; }
    }
}
