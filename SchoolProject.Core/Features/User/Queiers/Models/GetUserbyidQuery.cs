using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queiers.Response;

namespace SchoolProject.Core.Features.User.Queiers.Models
{
    public class GetUserbyidQuery : IRequest<Response<GetUserByidResponse>>
    {
        public int Id { get; set; }
        public GetUserbyidQuery(int id)
        {
            Id = id;
        }
    }
}
