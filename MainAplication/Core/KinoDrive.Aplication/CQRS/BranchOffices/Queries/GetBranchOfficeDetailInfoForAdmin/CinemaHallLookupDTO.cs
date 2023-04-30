using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;


namespace KinoDrive.Aplication.CQRS.BranchOffices.Queries.GetBranchOfficeDetailInfoForAdmin
{
    public class CinemaHallLookupDTO : IMapWith<CinemaHall>
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int NumOfRow { get; set; }
        public int NumOfPlacesInRow { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CinemaHall, CinemaHallLookupDTO>();
        }
    }
}
