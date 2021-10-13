using MediatR;
using ProjectName.Application.Accounts.Models;
using ProjectName.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Accounts.Queries.ConfirmEmail
{
    public class ConfirmEmailQuery : IRequest<AccountsVm>
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
    public class GetDesignationsQueryHandler : IRequestHandler<ConfirmEmailQuery, AccountsVm>
    {
        private readonly IIdentityService _identityService;
        public GetDesignationsQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<AccountsVm> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            return new AccountsVm
            {
                ConfirmEmail = await _identityService.ConfirmEmail(request.UserId, request.Code)
            };
        }
    }


}
