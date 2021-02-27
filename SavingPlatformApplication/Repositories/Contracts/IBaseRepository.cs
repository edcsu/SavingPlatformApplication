using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SavingPlatformApplication.Repositories.Contracts
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Get All records of a given entity
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync<T>( CancellationToken cancellationToken = default);

        /// <summary>
        /// Create an enntity
        /// </summary>
        /// <param name="t">Entity is of type T</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> AddAsync<T>(T t, CancellationToken cancellationToken = default);

        /// <summary>
        /// Check whether an entity of type T exists 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync<T>(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the total number of entities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetCountAsync<T>(CancellationToken cancellationToken = default);

        /// <summary>
        /// Find an entity of type T
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an entity of type T
        /// </summary>
        /// <param name="t"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> UpdateAsync<T>(T t, CancellationToken cancellationToken = default);
    }
}
