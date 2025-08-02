using AutoMapper;

namespace SchoolProject.Core.mapping.Usermappng
{
    public partial class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateUserCommandMapping();

        }
    }
}
