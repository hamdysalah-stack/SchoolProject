using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.models;
using SchoolProject.Core.SharedLocaResources;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                       IRequestHandler<AddStudentCommand, Response<string>>,
                                       IRequestHandler<EditStudentCommand, Response<string>>,
                                       IRequestHandler<DeleteStudentCommand, Response<string>>


    {

        #region fields

        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        public readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion



        #region Constructor
        public StudentCommandHandler(IStudentServices studentServices, IMapper mapper,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion


        #region handle Function
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and Student
            var student = _mapper.Map<Student>(request);
            //add student to database
            var result = await _studentServices.AddStudentAsync(student);
            //check Condition
            //if (result == "Student is Exist") return UnprocessableEntity<string>("Name is Exist");


            //return Response
            if (result == "Student added successfully") return Created("Student added successfully");

            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check if the id is Exist Or Not
            var Student = await _studentServices.GetByIdAsyncwithoutinclude(request.Id);
            if (Student == null)
                //return NotFound
                return NotFound<string>("Student Not Found");
            //mapping Between request and Student clone from Student
            var studentmapper = _mapper.Map(request, Student);

            // call Services  that make Edit
            var Oresult = await _studentServices.EditStudentAsync(studentmapper);
            // return Response
            if (Oresult == "Success") return Success($" Edit successfully {studentmapper.StudID}");

            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check if the id is Exist Or Not
            var Student = await _studentServices.GetByIdAsyncwithoutinclude(request.Id);
            if (Student == null)
                //return NotFound
                return NotFound<string>("Student Not Found");
            // call Services  that make Delete

            var Oresult = await _studentServices.DeleteAsync(Student);

            if (Oresult == "Success") return Deleted<string>($" Delete successfully {request.Id}");

            else return BadRequest<string>();


        }
        #endregion

    }
}
