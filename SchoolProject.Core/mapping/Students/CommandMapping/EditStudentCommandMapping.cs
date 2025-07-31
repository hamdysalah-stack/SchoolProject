using SchoolProject.Core.Features.Students.Commands.models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
            .ForMember(dest => dest.DID, opts => opts.MapFrom(src => src.DepartmentID))
            .ForMember(dest => dest.StudID, opts => opts.MapFrom(src => src.Id));

        }
    }
}
