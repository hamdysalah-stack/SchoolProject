using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Queries.models;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                             IRequestHandler<AuthorizeUserQuery, Response<string>>
    {



        #region  Fileds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        private readonly IAuthenticationServices _authenticationServices;

        #endregion


        #region  Constructor
        public AuthenticationQueryHandler(
            IAuthenticationServices authenticationServices,
        IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;

            _authenticationServices = authenticationServices;

        }

        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationServices.validateToken(request.AccessToken);
            if (result == "Not Expired")
            {
                return Success<string>(result);

            }

            return Unauthorized<string>("Token IS Expired");

        }
        #endregion


    }
}


