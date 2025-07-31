using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.models;
using SchoolProject.Core.Features.Departments.Queries.Response;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentByIdQueryHandlers : ResponseHandler,
                                             IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>

    {

        #region Fileds
        private readonly IdepartmentServices _idepartmentServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public DepartmentByIdQueryHandlers(IdepartmentServices idepartmentServices, IMapper mapper
                , IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _idepartmentServices = idepartmentServices;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;


        }
        #endregion

        #region Handle Function
        #endregion
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            // call servies get by id include student and subject and instructor

            var Oresponse = await _idepartmentServices.GetDepartmentById(request.Id);
            if (Oresponse == null)
            {
                //check  is not exist
                return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            //if exist ===> mapping

            var OresultMapper = _mapper.Map<GetDepartmentByIdResponse>(Oresponse);

            //pagination
            //Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Name);

            //retun response 

            return Success(OresultMapper);
        }
    }
}
//var filterQuery = _studentServices.FilterStudentPaginatedQuerable(
//    request.OrderBy ?? StudentOrderingEnum.StudID,
//    request.Search!
//);
//var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
//return paginatedList;