using MediatR;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Application.Users.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Users.Queries.GetUsers
{
    public class GetUserListQuery : IRequest<UsersVm>
    {
    }
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UsersVm>
    {
        private readonly IIdentityService _identityService;
        public GetUserListQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UsersVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return new UsersVm
            {
                UserList = await _identityService.GetUserListAsync()
            };
        }
    }
}
