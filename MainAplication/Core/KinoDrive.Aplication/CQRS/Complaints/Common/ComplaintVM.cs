using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Complaints.Common
{
    public class ComplaintVM : IMapWith<Complaint>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? Answer { get; set; }

        public string UserNickName { get; set; }

        public string? BranchOfficeName { get; set; }
        public string? BranchOfficeCity{ get; set; }

        public DateTime CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Complaint, ComplaintVM>()
                .ForMember(c => c.UserNickName,
                opt => opt.MapFrom(complaint => complaint.User.NickName))
                .ForMember(c => c.BranchOfficeName,
                opt => opt.MapFrom(complaint => complaint.BranchOffice == null ? null : complaint.BranchOffice.Name))
                .ForMember(c => c.BranchOfficeCity,
                opt => opt.MapFrom(complaint => complaint.BranchOffice == null ? null : complaint.BranchOffice.City));
        }
    }
}
