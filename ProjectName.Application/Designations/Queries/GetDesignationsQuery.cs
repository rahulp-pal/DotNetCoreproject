using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Application.Designations.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Designations.Queries
{
    public class GetDesignationsQuery : IRequest<DesignationsVm>
    {
    }
    public class GetDesignationsQueryHandler : IRequestHandler<GetDesignationsQuery, DesignationsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetDesignationsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DesignationsVm> Handle(GetDesignationsQuery request, CancellationToken cancellationToken)
        {
            return new DesignationsVm
            {
                Lists = await _context.Designations
                     .ProjectTo<DesignationDto>(_mapper.ConfigurationProvider)
                     .OrderBy(t => t.Name)
                     .ToListAsync(cancellationToken)
            };
        }
    }
}
