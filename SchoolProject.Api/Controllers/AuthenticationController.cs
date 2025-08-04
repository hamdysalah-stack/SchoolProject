using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commants.Models;
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
    }
}
