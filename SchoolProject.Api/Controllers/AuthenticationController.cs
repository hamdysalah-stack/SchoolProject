using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commants.Models;
using SchoolProject.Core.Features.Authentication.Queries.models;
using SchoolProject.Data.AppRoutes;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {

        [HttpPost(Router.AuthenticationRouting.SignIn)]

        public async Task<IActionResult> create([FromForm] SignInCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }



        [HttpPost(Router.AuthenticationRouting.RefreshToken)]

        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }


        [HttpGet(Router.AuthenticationRouting.ValidateToken)]

        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserQuery command)
        {
            var Oresult = await Mediator.Send(command);

            return NewResult(Oresult);

        }
    }
}
