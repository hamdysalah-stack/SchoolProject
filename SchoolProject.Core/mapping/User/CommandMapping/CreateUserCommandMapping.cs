using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Data.Entities.Idenitiy;

namespace SchoolProject.Core.mapping.Usermappng
{
    public partial class UserProfile
    {

        public void CreateUserCommandMapping()
        {

            //create mapping for AddUserCommand Src to Users dest entity
            CreateMap<AddUserCommand, Users>()
     .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
     .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
     .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
     .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

        }
    }
}


