

namespace KinoDrive.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
        public IEnumerable<Complaint> Complaintes { get; set; } = new List<Complaint>();
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();

        public string Role { get; set; }
    }
}
