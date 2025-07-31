using SchoolProject.Core.Features.Departments.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.mapping.DepartmentMapper
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentbyIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()

                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.DID))
                 .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Supervisor.insName))
                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                 .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));



            CreateMap<DepartmetSubject, SubjectResponse>()
                                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.SubID))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.SubjectName));



            CreateMap<Student, StudentResponse>()
                                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.StudID))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));



            CreateMap<Instructor, InstructorResponse>()
                                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.InsId))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.insName));





        }
    }
}
