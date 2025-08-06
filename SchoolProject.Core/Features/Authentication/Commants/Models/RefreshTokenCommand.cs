using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commants.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuhtResult>>
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;


    }
}
