using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
  /// <summary>
  /// Defines a generic repository interface
  /// </summary>
  /// <typeparam name="T">Specifies which class is concerned by the repository interface</typeparam>
  public interface IAsyncRepository<T> where T : class
  {
    /// <summary>
    /// Get a collection of sorted and filtered objects as seen here:
    /// </summary>
    /// <param name="filter">Lambda expression to filter results</param>
    /// <param name="orderBy">Lambda expression to order results</param>
    /// <param name="select">Lambda expression to select fields</param>
    /// <param name="include">Related entities to load as navigation properties</param>
    /// <param name="isTrackingDisable">Disable tracking if set to true</param>
    /// <param name="isSplitQuery">Splits query if set to true</param>
    /// <returns></returns>
    IEnumerable<T> Get(
      Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      Expression<Func<T, T>> select = null,
      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
      bool isTrackingDisable = false,
      bool isSplitQuery = false);
    /// <summary>
    /// Get an object by its keys
    /// </summary>
    /// <param name="keys">Keys of the object we want to retrieve (can be a single id or a composite key</param>
    /// <returns>The object matching the keys passed as parameter</returns>
    Task<T> GetByIdAsync(params object[] keys);
    /// <summary>
    /// List all objects
    /// </summary>
    /// <returns>List of all objects</returns>
    Task<IReadOnlyList<T>> ListAllAsync();
    /// <summary>
    /// Add a new object
    /// </summary>
    /// <param name="entity">The new object to add</param>
    /// <returns>The newly created object</returns>
    Task<T> AddAsync(T entity);
    /// <summary>
    /// Update an object
    /// </summary>
    /// <param name="entity">The object to be updated</param>
    /// <returns>A task</returns>
    Task UpdateAsync(T entity);
  }
}
