

namespace KinoDrive.Domain
{
    public class User
    {
        public int Id { get; set; }
        public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        public IEnumerable<Complaint> Complaintes { get; set; } = new List<Complaint>();
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
    }
}
