using SchoolProject.Core.Features.User.Queiers.Response;
using SchoolProject.Data.Entities.Idenitiy;

namespace SchoolProject.Core.mapping.Usermappng
{
    public partial class UserProfile
    {

        public void GetUserlistMapping()
        {
            CreateMap<Users, GetUserListresponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));


        }
    }
}


