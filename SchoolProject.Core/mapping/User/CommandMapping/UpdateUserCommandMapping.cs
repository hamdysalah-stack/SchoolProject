using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Data.Entities.Idenitiy;

namespace SchoolProject.Core.mapping.Usermappng
{
    public partial class UserProfile
    {
        public void UpdateUserCommandMapping()
        {

            CreateMap<UpdateUserCommand, Users>();



        }
    }
}
