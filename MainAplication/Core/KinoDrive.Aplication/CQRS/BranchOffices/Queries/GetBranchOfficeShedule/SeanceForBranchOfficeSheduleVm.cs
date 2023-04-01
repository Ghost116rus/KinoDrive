using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{
    public class SeanceForBranchOfficeSheduleVm : IMapWith<SeanceForBranchOfficeSheduleList>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int BasicCost { get; set; }
        public TimeSpan SeanceStartTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeanceForBranchOfficeSheduleList, SeanceForBranchOfficeSheduleVm>()
                .ForMember(s => s.SeanceStartTime,
                opt => opt.MapFrom(s => s.SeanceStartTime.TimeOfDay));
        }
    }
}
