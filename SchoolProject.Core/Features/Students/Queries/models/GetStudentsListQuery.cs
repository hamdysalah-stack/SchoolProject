

using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Students.Queries.models
{
    public class GetStudentsListQuery:IRequest<Response<List<GetStudentsListResponse>>>
    {


    }
}
