using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Application.Common.Interfaces;
using ProjectName.Application.Employees.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<EmployeesVm>
    {
    }
   
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetEmployeesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeesVm> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return new EmployeesVm
            {
                Lists = await _context.Employees
                     .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                     .OrderBy(t => t.FirstName)
                     .ToListAsync(cancellationToken)
            };
        }
    }
}
