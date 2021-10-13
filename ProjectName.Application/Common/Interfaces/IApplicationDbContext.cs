using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Designation> Designations { get; set; }
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
