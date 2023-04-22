using AutoMapper;
using KinoDrive.Aplication.Common.Mappings;
using KinoDrive.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Reviews.Queries.GetFilmReviewsByID
{
    public class ReviewLookUpDTO : IMapWith<Review>
    {
        public int UserId { get; set; }
        public string UserNickName { get; set; }
        public int Value { get; set; }
        public DateTime ChangeDate { get; set; }
        public string? Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewLookUpDTO>()
                .ForMember(r => r.UserNickName,
                opt => opt.MapFrom(orig => orig.User.NickName));
        }


    }
}
