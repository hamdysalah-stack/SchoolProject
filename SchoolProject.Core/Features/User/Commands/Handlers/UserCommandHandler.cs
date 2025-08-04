using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Data.Entities.Idenitiy;

namespace SchoolProject.Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                    IRequestHandler<AddUserCommand, Response<string>>,
                                   IRequestHandler<UpdateUserCommand, Response<string>>,
                                    IRequestHandler<DeleteUserCommand, Response<string>>,
                                    IRequestHandler<ChangeUserPasswordCommand, Response<string>>
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

            return Created<string>("Add User");
        }

        #region AddUserCommand
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

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            //check if user exist
            var Olduser = await _userManager.FindByIdAsync(request.Id.ToString());
            //not found

            if (Olduser == null)
                return NotFound<string>("UserNotFound");

            var Newuser = _mapper.Map(request, Olduser);

            var UserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.Id != Newuser.Id);
            if (UserName != null)
                return BadRequest<string>("UserNameAlreadyExist");

            //mapping UserCommand to User Entity


            //update user
            var UpdateUser = await _userManager.UpdateAsync(Olduser);

            //result is not success
            if (!UpdateUser.Succeeded)
            {
                //return BadRequest
                return BadRequest<string>(UpdateUser.Errors.FirstOrDefault().Description);
            }

            //return success response
            return Updated("Update User");
        }

        public Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //check if user exist
            var Olduser = _userManager.FindByIdAsync(request.Id.ToString());
            //not found
            if (Olduser == null)
                return Task.FromResult(NotFound<string>("UserNotFound"));
            //delete user
            var DeleteUser = _userManager.DeleteAsync(Olduser.Result);
            //result is not success
            if (!DeleteUser.Result.Succeeded)
            {
                //return BadRequest
                return Task.FromResult(BadRequest<string>(DeleteUser.Result.Errors.FirstOrDefault().Description));
            }
            //return success response
            return Task.FromResult(Deleted<string>("Deleted User"));
        }

        public Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //check if user exist
            var Olduser = _userManager.FindByIdAsync(request.Id.ToString());
            //not found
            if (Olduser == null)
                return Task.FromResult(NotFound<string>("UserNotFound"));
            //check current password is correct
            var CheckPassword = _userManager.CheckPasswordAsync(Olduser.Result, request.CurrentPassword);
            if (!CheckPassword.Result)
                return Task.FromResult(BadRequest<string>("Current Password is not Correct"));
            //change password
            var ChangePassword = _userManager.ChangePasswordAsync(Olduser.Result, request.CurrentPassword, request.NewPassword);
            if (!ChangePassword.Result.Succeeded)
                return Task.FromResult(BadRequest<string>(ChangePassword.Result.Errors.FirstOrDefault().Description));
            //return success response
            return Task.FromResult(Change<string>("Change Password"));

        }
        #endregion
    }
}
