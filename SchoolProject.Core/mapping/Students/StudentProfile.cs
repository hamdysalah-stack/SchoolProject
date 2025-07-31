using AutoMapper;

namespace SchoolProject.Core.mapping.StudentMapper
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentbyIdMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
