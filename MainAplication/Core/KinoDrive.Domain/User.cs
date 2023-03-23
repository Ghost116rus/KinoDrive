

namespace KinoDrive.Domain
{
    public class User
    {
        public int Id { get; set; }
        public IEnumerable<Complaint> Complaintes { get; set; } = new List<Complaint>();
    }
}
