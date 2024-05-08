using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using Application.Contracts.Persistence;

namespace Persistence.Repositories
{
  /// <summary>
  /// Implementation of the generic IAsyncRepository interface
  /// </summary>
  /// <typeparam name="T">Class of the domain object concerned by the repository</typeparam>
  /// <typeparam name="TId">Type of the id of the domain object (will probably be Guid or int)</typeparam>
  public class BaseRepository<T> : IAsyncRepository<T> where T : class
  {
    internal VotingDbContext context;
    internal DbSet<T> dbSet;

    /// <inheritdoc/>
    public BaseRepository(VotingDbContext dbContext)
    {
      context = dbContext;
      dbSet = dbContext.Set<T>();
    }

    /// <inheritdoc/>
    public async Task<T> AddAsync(T entity)
    {
      await dbSet.AddAsync(entity);
      await context.SaveChangesAsync();

      return entity;
    }

    /// <inheritdoc/>
    public virtual IEnumerable<T> Get(
      Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      Expression<Func<T, T>> select = null,
      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
      bool isTrackingDisable = false,
      bool isSplitQuery = false)
    {
      IQueryable<T> query = dbSet;

      if (isTrackingDisable)
      {
        query = query.AsNoTracking();
      }

      if (include != null)
      {
        query = include(query);
      }

      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (orderBy != null)
      {
        query = orderBy(query);
      }

      if (select != null)
      {
        query = query.Select(select);
      }

      if (isSplitQuery)
      {
        query = query.AsSplitQuery();
      }

      return query.ToList();
    }

    /// <inheritdoc/>
    public virtual async Task<T> GetByIdAsync(params object[] keys)
    {
      return await dbSet.FindAsync(keys);
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
      return await context.Set<T>().ToListAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(T entity)
    {
      dbSet.Attach(entity);
      context.Entry(entity).State = EntityState.Modified;
      await context.SaveChangesAsync();
    }
  }
}
