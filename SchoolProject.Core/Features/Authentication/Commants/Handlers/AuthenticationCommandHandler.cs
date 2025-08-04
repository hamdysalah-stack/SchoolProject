using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commants.Models;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Data.Entities.Idenitiy;
using SchoolProject.Data.Helpers;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Authentication.Commants.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                             IRequestHandler<SignInCommand, Response<JwtAuhtResult>>
    {



        #region  Fileds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;

        #endregion


        #region  Constructor
        public AuthenticationCommandHandler(IMapper mapper,
            UserManager<Users> userManager,
            SignInManager<Users> signInManager,
            IAuthenticationServices authenticationServices,
        IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationServices = authenticationServices;

        }
        #endregion

        public async Task<Response<JwtAuhtResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //check if userName exists Or Not
            var user = await _userManager.FindByNameAsync(request.UserName);
            // Return UserName Not Found
            if (user == null)
            {
                return BadRequest<JwtAuhtResult>("UserNameOrPasswordIsNotCorrect");
            }
            //Try  to sign in the user
            var SignIn = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            //if failed return BadRequest Password or UserName is not correct
            if (!SignIn.Succeeded)
            {
                return BadRequest<JwtAuhtResult>("UserNameOrPasswordIsNotCorrect");
            }

            // Generate token
            var token = await _authenticationServices.GetJWTTokenAsync(user);
            return Login<JwtAuhtResult>(token, "LoginSuccess");
        }
    }
}
