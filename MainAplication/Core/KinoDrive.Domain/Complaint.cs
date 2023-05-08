

namespace KinoDrive.Domain
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int BranchOfficeId { get; set; }
        public BranchOffice BranchOffice { get; set; }
    }
}
