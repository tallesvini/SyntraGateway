using Microsoft.EntityFrameworkCore;
using Syntra.BuildingBlocks.Application.Abstractions.Persistence;

namespace Syntra.BuildingBlocks.Infrastructure.Persistence
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
