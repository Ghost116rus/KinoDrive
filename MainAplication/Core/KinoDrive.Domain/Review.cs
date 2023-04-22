using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Domain
{
    public class Review
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public int Value { get; set; }
        public DateTime ChangeDate { get; set; }
        public User User { get; set; }
        public Film Film { get; set; }
        public string? Description { get; set; }
    }
}
