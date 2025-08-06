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
                                             IRequestHandler<SignInCommand, Response<JwtAuhtResult>>,
                                             IRequestHandler<RefreshTokenCommand, Response<JwtAuhtResult>>
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

        public async Task<Response<JwtAuhtResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var JwtToken = _authenticationServices.ReadJwtToken(request.AccessToken);


            var userIdandExporedDate = await _authenticationServices.ValidateDetails(JwtToken, request.AccessToken, request.RefreshToken);


            switch (userIdandExporedDate)
            {
                case ("AlgorithmsIsNotEqual", null): return Unauthorized<JwtAuhtResult>("AlgorithmsIsNotEqual");
                case ("TokenisnotExpired", null): return Unauthorized<JwtAuhtResult>("TokenisnotExpired");
                case ("RefreshTokenisnotfound", null): return Unauthorized<JwtAuhtResult>("RefreshTokenisnotfound");
                case ("REfreshTokenisExpired", null): return Unauthorized<JwtAuhtResult>("REfreshTokenisExpired");
            }

            var (userId, expireDate) = userIdandExporedDate;
            var User = await _userManager.FindByIdAsync(userId);
            if (User == null)
                return NotFound<JwtAuhtResult>("User is  Not found ");


            var result = await _authenticationServices.GetRefreshToken(User, JwtToken, expireDate, request.RefreshToken);
            return Success(result, "freshTokenSuccess");
        }
    }
}
