using AutoMapper;

namespace SchoolProject.Core.mapping.DepartmentMapper
{
    public partial class DepartmentProfile : Profile
    {

        public DepartmentProfile()
        {
            GetDepartmentbyIdMapping();
        }
    }
}
