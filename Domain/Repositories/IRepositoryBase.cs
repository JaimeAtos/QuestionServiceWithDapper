using Atos.Core.Abstractions;

namespace Domain.Repositories;

public interface IRepositoryBase<TKey, TUserKey, TEntity> where TEntity : class, IEntityBase<TKey, TUserKey>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity> GetEntityByIdAsync(TKey Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="param"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync(object? param = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TKey> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(TEntity entity, TKey Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(TKey Id, CancellationToken cancellationToken = default);
}
