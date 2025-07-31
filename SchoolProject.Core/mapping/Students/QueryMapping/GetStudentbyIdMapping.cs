using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.mapping.StudentMapper
{
    public partial class StudentProfile
    {

        public void GetStudentbyIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
            .ForMember(dest => dest.DepartmantName, opts => opts.MapFrom(src => src.Department.DName));
        }
    }
}
