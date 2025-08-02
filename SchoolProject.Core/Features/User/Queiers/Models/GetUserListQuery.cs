using MediatR;
using SchoolProject.Core.Features.User.Queiers.Response;
using SchoolProject.Core.Wrapper;

namespace SchoolProject.Core.Features.User.Queiers.Models
{
    public class GetUserListQuery : IRequest<PaginatedResult<GetUserListresponse>>
    {
        public int PageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
