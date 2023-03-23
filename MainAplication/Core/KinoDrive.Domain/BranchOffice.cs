

namespace KinoDrive.Domain
{
    public class BranchOffice
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public IEnumerable<CinemaHall> CinemaHalls { get; set; } = new List<CinemaHall>();
        public IEnumerable<Complaint> Complaintes { get; set; } = new List<Complaint>();
    }
    
}
