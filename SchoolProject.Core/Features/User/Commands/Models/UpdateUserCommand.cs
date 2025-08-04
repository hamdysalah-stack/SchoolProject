using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.User.Commands.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        //public string Password { get; set; } = string.Empty;

        //public string ConfirmPassword { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Country { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
