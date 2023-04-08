using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeShedule
{
    public class SeanceForBranchOfficeSheduleList : IMapWith<Seance>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int BasicCost { get; set; }
        public DateTime SeanceStartTime { get; set; }
        public FIlmVM Film { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Seance, SeanceForBranchOfficeSheduleList>();
        }
    }
}
