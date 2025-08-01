using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Queries.models;
using SchoolProject.Data.AppRoutes;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {

        [HttpGet(Router.DepartmentRouting.Getyid)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var Oresult = await Mediator.Send(new GetDepartmentByIdQuery(id));

            return NewResult(Oresult);

        }
    }
}
