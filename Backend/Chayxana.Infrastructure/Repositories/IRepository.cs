using System.Linq.Expressions;

namespace Chayxana.Infrastructure.Repositories;

public interface IRepository<TEntity>
{
    Task<IQueryable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null, CancellationToken cancellationToken = default);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null, CancellationToken cancellationToken = default); 
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default);
    Task<bool> SaveAsync(CancellationToken cancellationToken = default);
}