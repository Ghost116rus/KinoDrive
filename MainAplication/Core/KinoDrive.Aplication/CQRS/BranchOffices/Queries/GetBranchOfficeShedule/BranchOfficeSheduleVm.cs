

namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{
    public class FilmsForSheduleVM
    {
        public FIlmVM Film { get; set; }
        public IList<SeanceForBranchOfficeSheduleVm> Seances { get; set; }
    }

    public class DatesForSheduleVM
    {
        public string Date { get; set; }

        public IList<FilmsForSheduleVM> Films { get; set; }
    }

    public class BranchOfficeSheduleVm
    {
        public IList<DatesForSheduleVM> SessionShedule { get; set; }
    }
}
