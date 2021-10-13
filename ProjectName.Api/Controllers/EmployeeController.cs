using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Controllers;
using ProjectName.Application.Employees.Models;
using ProjectName.Application.Employees.Queries;
using System.Threading.Tasks;

namespace ProjectName.ProjectName.Api
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<EmployeesVm>> Get()
        {
            return await Mediator.Send(new GetEmployeesQuery());
        }
    }
}
