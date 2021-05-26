using System;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Api.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Save entities
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
