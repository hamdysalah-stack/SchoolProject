using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Core.Features.User.Queiers.Models;
using SchoolProject.Data.AppRoutes;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : AppControllerBase
    {
        [HttpPost(Router.UserRouting.Create)]

        public async Task<IActionResult> create([FromBody] AddUserCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }

        [AllowAnonymous]
        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> PaginatedUser([FromQuery] GetUserListQuery listQuery)
        {
            var Oresult = await Mediator.Send(listQuery);

            return Ok(Oresult);

        }


        [HttpGet(Router.UserRouting.Getyid)]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var Oresult = await Mediator.Send(new GetUserbyidQuery(id));

            return NewResult(Oresult);

        }


        [HttpPut(Router.UserRouting.Edit)]

        public async Task<IActionResult> Edit([FromBody] UpdateUserCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }

        [HttpDelete(Router.UserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Oresult = await Mediator.Send(new DeleteUserCommand(id));
            return NewResult(Oresult);
        }

        [HttpPut(Router.UserRouting.ChangePassword)]

        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }

    }
}