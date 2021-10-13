using MediatR;
using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Accounts.Commands.ForgotPassword
{
    public partial class ForgotPasswordCommand : IRequest<string>
    {
        public string Email { get; set; }
    }
    public class AuthenticateUserCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly IIdentityService _identityService;
        public AuthenticateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var userInput = new ForgotPasswordDto { Email = request.Email};
            return await _identityService.ForgotPassword(userInput);
        }
    }

}
