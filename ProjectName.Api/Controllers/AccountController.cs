using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Application.Accounts.Commands.AuthenticateUser;
using ProjectName.Application.Accounts.Commands.ForgotPassword;
using ProjectName.Application.Accounts.Commands.Logout;
using ProjectName.Application.Accounts.Commands.ResetPassword;
using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Accounts.Queries.ConfirmEmail;
using System.Threading.Tasks;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class AccountController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Login(AuthenticateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<AccountsVm>> ConfirmEmail(string id = null, string code = null)
        {
            if (id == null)
            {
                return BadRequest("A Id must be supplied for password reset.");
            }
            else if (code == null)
            {
                return BadRequest("A Code must be supplied for password reset.");
            }
            return await Mediator.Send(new ConfirmEmailQuery { UserId = id, Code = code });
        }

        [HttpPost]
        public async Task<ActionResult<string>> ForgotPassword(ForgotPasswordCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public ActionResult<string> ResetPassword(string code = null)
        {
            if (code == null)
            {
                return BadRequest("A code must be supplied for password reset.");
            }
            return Ok(code);
        }

        [HttpPost]
        public async Task<ActionResult<string>> ResetPassword(ResetPasswordCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Logout(LogoutCommand command)
        {
            return await Mediator.Send(command);
        }

    }
}
