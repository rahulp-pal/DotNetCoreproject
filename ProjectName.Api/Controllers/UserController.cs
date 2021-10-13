using Microsoft.AspNetCore.Mvc;
using ProjectName.Application.Common.Models;
using ProjectName.Application.Users.Commands.CreateUser;
using ProjectName.Application.Users.Models;
using ProjectName.Application.Users.Queries.GetUsers;
using System.Threading.Tasks;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<(Result, string)>> CreateUser(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<UsersVm>> GetUserList()
        {
            return await Mediator.Send(new GetUserListQuery());
        }

        [HttpGet]
        public async Task<ActionResult<UsersVm>> GetUser(string userId)
        {
            return await Mediator.Send(new GetUserQuery { UserId = userId });
        }
    }
}
