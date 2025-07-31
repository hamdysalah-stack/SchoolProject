using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Core.Wrapper;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Services.Interface;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    internal class StudentsQueryHandlers : ResponseHandler,
                                        IRequestHandler<GetStudentsListQuery, Response<List<GetStudentsListResponse>>>,
                                        IRequestHandler<GetStudentsByIDQuery, Response<GetSingleStudentResponse>>,
                                         IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {

        #region fileds
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        public readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructor
        public StudentsQueryHandlers(IStudentServices studentServices, IMapper mapper,

               IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion

        #region Handle function
        public async Task<Response<List<GetStudentsListResponse>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var StudentsList = await _studentServices.GetStudentsListAsync();
            var StudentsListMapper = _mapper.Map<List<GetStudentsListResponse>>(StudentsList);
            return Success(StudentsListMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentsByIDQuery request, CancellationToken cancellationToken) // Fixed type signature here
        {
            var student = await _studentServices.GetStudentByIdwithIincludeAsync(request.Id);
            if (student == null)
                //return NotFound<GetSingleStudentResponse>("Object not Found
                return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);


            var Oresult = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(Oresult);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address!, e.Department!.DName!);
            var filterQuery = _studentServices.FilterStudentPaginatedQuerable(
                request.OrderBy ?? StudentOrderingEnum.StudID,
                request.Search!
            );
            var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }


        #endregion
    }
}
