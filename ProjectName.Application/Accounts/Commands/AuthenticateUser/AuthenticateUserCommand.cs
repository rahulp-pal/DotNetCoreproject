using MediatR;
using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Accounts.Commands.AuthenticateUser
{
    public partial class AuthenticateUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IIdentityService _identityService;
        public AuthenticateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var userInput = new LoginDto { Email = request.Email, Password = request.Email, RememberMe = request.RememberMe };
            return await _identityService.AuthenticateUser(userInput);
        }
    }
}