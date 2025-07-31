using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.mapping.StudentMapper
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentsListResponse>()
              .ForMember(dest => dest.DepartmantName, opts => opts.MapFrom(src => src.Department.DName));
        }
    }
}
