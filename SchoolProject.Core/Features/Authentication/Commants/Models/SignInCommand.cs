using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commants.Models
{
    public class SignInCommand : IRequest<Response<JwtAuhtResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
