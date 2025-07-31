using SchoolProject.Core.Wrapper;

namespace SchoolProject.Core.Features.Departments.Queries.Response
{
    public class GetDepartmentByIdResponse
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int? ManagerName { get; set; }

        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }

    }

    public class StudentResponse
    {
        public int id { get; set; }
        public string Name { get; set; }

        public StudentResponse(string name, int Id)
        {
            Name = name;
            id = Id;
        }
    }

    public class InstructorResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

    public class SubjectResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
