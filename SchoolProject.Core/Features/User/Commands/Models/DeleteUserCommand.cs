using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.User.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
