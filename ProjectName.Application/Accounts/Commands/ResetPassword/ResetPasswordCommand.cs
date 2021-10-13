using MediatR;
using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Accounts.Commands.ResetPassword
{
    public partial class ResetPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
    public class AuthenticateUserCommandHandler : IRequestHandler<ResetPasswordCommand, string>
    {
        private readonly IIdentityService _identityService;
        public AuthenticateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var userInput = new ResetPasswordDto { Email = request.Email, Password = request.Password, ConfirmPassword = request.ConfirmPassword, Code = request.Code };
            return await _identityService.ResetPassword(userInput);
        }
    }
}