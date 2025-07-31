using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        //[Required]
        public string? Name { get; set; }
        //[Required]
        public string? Address { get; set; }
        public string Phone { get; set; }

        public string? DepartmentID { get; set; }
    }
}
