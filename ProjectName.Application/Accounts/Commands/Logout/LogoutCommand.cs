using MediatR;
using ProjectName.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Accounts.Commands.Logout
{
    public partial class LogoutCommand : IRequest<string>
    {    }
    public class AuthenticateUserCommandHandler : IRequestHandler<LogoutCommand, string>
    {
        private readonly IIdentityService _identityService;
        public AuthenticateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.Logout();
        }
    }
}
