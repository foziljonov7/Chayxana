using System.Linq.Expressions;
using Chayxana.DAL.Data.Contexts;
using Chayxana.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext dbContext;
    DbSet<TEntity> dbSet;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<TEntity>();
    }
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => (await dbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false)).Entity;

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await dbSet
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            .ConfigureAwait(false);

        dbSet.Remove(entity);
        return true;
    }

    public async Task<bool> ExistsAsync(long id, CancellationToken cancellationToken = default)
        => await dbSet.AnyAsync(x => x.Id == id, cancellationToken);

    public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
        => await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;

    public Task<IQueryable<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null, CancellationToken cancellationToken = default)
    {
        return Task.Run(async () => 
        {
            var query = predicate is null ? dbSet : dbSet.Where(predicate);

            if(includes is not null)
                foreach(var include in includes)
                    query = query.Include(include);

            return query;
        }, cancellationToken);
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null, CancellationToken cancellationToken = default)
    {
        var query = await SelectAllAsync(predicate, includes, cancellationToken).ConfigureAwait(false);
        return await query.FirstOrDefaultAsync(predicate, cancellationToken).ConfigureAwait(false);
    }

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        => Task.Run(() => dbSet.Update(entity).Entity, cancellationToken);
}
