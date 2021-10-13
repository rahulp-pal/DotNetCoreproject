using MediatR;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Application.Common.Models;
using ProjectName.Application.Users.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Users.Commands.CreateUser
{
    public partial class CreateUserCommand : IRequest<(Result, string)>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, (Result, string)>
    {
        private readonly IIdentityService _identityService;
        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<(Result, string)> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userInput = new CreateUserDto { Email = request.Email, PhoneNumber = request.PhoneNumber, Password = request.Password };
            return _identityService.CreateUserAsync(userInput);
        }
    }
}