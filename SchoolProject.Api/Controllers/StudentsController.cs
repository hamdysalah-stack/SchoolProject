using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.models;
using SchoolProject.Core.Features.Students.Queries.models;
using SchoolProject.Data.AppRoutes;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentsController : AppControllerBase
    {




        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var Oresult = await Mediator.Send(new GetStudentsListQuery());

            return NewResult(Oresult);

        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> PaginatedStudents([FromQuery] GetStudentPaginatedListQuery listQuery)
        {
            var Oresult = await Mediator.Send(listQuery);

            return Ok(Oresult);

        }


        [HttpGet(Router.StudentRouting.Getyid)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var Oresult = await Mediator.Send(new GetStudentsByIDQuery(id));

            return NewResult(Oresult);

        }

        [HttpPost(Router.StudentRouting.Create)]

        public async Task<IActionResult> create([FromBody] AddStudentCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }

        [HttpPut(Router.StudentRouting.Edit)]

        public async Task<IActionResult> Edit([FromBody] EditStudentCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Oresult = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(Oresult);
        }


    }
}
