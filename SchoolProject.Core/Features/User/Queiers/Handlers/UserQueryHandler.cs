using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queiers.Models;
using SchoolProject.Core.Features.User.Queiers.Response;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Entities.Idenitiy;

namespace SchoolProject.Core.Features.User.Queiers.Handlers
{
    public class UserQueryHandler : ResponseHandler
                                     , IRequestHandler<GetUserListQuery, PaginatedResult<GetUserListresponse>>
                                     , IRequestHandler<GetUserbyidQuery, Response<GetUserByidResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Users> _userManager;

        public UserQueryHandler(
            UserManager<Users> userManager,
            IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper)
            : base(stringLocalizer)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetUserListresponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var User = _userManager.Users.AsQueryable();

            var paginatedList = await _mapper.ProjectTo<GetUserListresponse>(User)
                                          .ToPaginatedListAsync(request.PageNumber, request.pageSize);
            return paginatedList;
        }

        public async Task<Response<GetUserByidResponse>> Handle(GetUserbyidQuery request, CancellationToken cancellationToken)
        {

            var User = await _userManager.Users.FirstOrDefaultAsync(Users => Users.Id == request.Id);
            //var User1 = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null)
            {
                return NotFound<GetUserByidResponse>("User not found");
            }

            var userResponse = _mapper.Map<GetUserByidResponse>(User);
            return Success(userResponse, "User found successfully");
        }
    }
}
