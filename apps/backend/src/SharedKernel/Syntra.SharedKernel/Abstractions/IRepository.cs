namespace Syntra.SharedKernel.Abstractions
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        Task AddAsync(TEntity value, CancellationToken cancellationToken = default);
    }
}
