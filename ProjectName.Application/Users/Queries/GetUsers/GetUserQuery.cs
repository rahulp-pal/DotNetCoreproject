using MediatR;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Application.Users.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Users.Queries.GetUsers
{
    public class GetUserQuery : IRequest<UsersVm>
    {
        public string UserId { get; set; }
    }
    public class GetDesignationsQueryHandler : IRequestHandler<GetUserQuery, UsersVm>
    {
        private readonly IIdentityService _identityService;
        public GetDesignationsQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UsersVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return new UsersVm
            {
                UserName = await _identityService.GetUserNameAsync(request.UserId)
            };
        }
    }
}
