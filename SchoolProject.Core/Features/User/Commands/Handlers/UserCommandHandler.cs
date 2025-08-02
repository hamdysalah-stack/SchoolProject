using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Data.Entities.Idenitiy;

namespace SchoolProject.Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                    IRequestHandler<AddUserCommand, Response<string>>
    {

        #region  Fileds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;

        private readonly UserManager<Users> _userManager;

        #endregion


        #region  Constructor
        public UserCommandHandler(IMapper mapper, UserManager<Users> userManager, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion



        #region Handle Functions

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var UserEmail = await _userManager.FindByEmailAsync(request.Email);
            if (UserEmail != null)
                return BadRequest<string>("EmailAlreadyExist");

            var UserName = await _userManager.FindByNameAsync(request.UserName);
            if (UserName != null)
                return BadRequest<string>("UserNameAlreadyExist");

            var user = _mapper.Map<Users>(request);

            var CeaUser = await _userManager.CreateAsync(user, request.Password);

            if (!CeaUser.Succeeded)
            {
                // Collect all errors and return them in the response
                //var errors = string.Join("; ", CeaUser.Errors.Select(e => e.Description));
                //return BadRequest<string>($"Failed to Create User: {errors}");
                return BadRequest<string>(CeaUser.Errors.FirstOrDefault().Description);
            }

            return Success<string>("Add User");
        }
        //public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        //{
        //    //if Email is Exist
        //    var UserEmail = await _userManager.FindByEmailAsync(request.Email);
        //    //already exist 
        //    if (UserEmail != null)
        //    {
        //        return BadRequest<string>("EmailAlreadyExist");
        //    }

        //    //if UserName is Exist
        //    var UserName = await _userManager.FindByNameAsync(request.UserName);
        //    if (UserName != null)
        //    {
        //        return BadRequest<string>("UserNameAlreadyExist");
        //    }

        //    //mapping UserCommand to User Entity
        //    var user = _mapper.Map<Users>(request);

        //    //Create User
        //    //send user for mapping in createe user and send password from request
        //    var CeaUser = await _userManager.CreateAsync(user, request.Password);

        //    //Failed
        //    if (!CeaUser.Succeeded)
        //    {
        //        //return BadRequest
        //        return BadRequest<string>("Failed to Create User");
        //    }

        //    //create Success

        //    //return
        //    return Success<string>("Add USer");


        //}
        #endregion

    }
}
