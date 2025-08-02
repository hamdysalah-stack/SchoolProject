using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.User.Commands.Models;
using SchoolProject.Data.AppRoutes;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpPost(Router.UserRouting.Create)]

        public async Task<IActionResult> create([FromBody] AddUserCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }
    }
}
