using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public StudentOrderingEnum? OrderBy { get; set; }

        public string? Search { get; set; }

    }
}
