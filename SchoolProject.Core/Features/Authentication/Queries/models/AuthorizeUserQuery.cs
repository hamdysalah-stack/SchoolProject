using MediatR;

namespace SchoolProject.Core.Features.Authentication.Queries.models
{
    public class AuthorizeUserQuery : IRequest<Bases.Response<string>>
    {

        public string AccessToken { get; set; } = string.Empty;

    }
}
