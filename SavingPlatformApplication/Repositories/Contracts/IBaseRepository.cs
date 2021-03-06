﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels;

namespace SavingPlatformApplication.Repositories.Contracts
{
    public interface IBaseRepository
    {

        /// <summary>
        ///   Gets a paginated list of all items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">Request with paged components</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<List<T>> GetAllPagedListAsync<T>(SearchRequest request, CancellationToken cancellation = default)
            where T : BaseModel;

        /// <summary>
        /// Get All records of a given entity
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync<T>( CancellationToken cancellationToken = default) where T : BaseModel;

        /// <summary>
        /// Create an enntity
        /// </summary>
        /// <param name="t">Entity is of type T</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> AddAsync<T>(T t, CancellationToken cancellationToken = default) where T : BaseModel;

        /// <summary>
        /// Check whether an entity of type T exists 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseModel;

        /// <summary>
        /// Get the total number of entities
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetCountAsync<T>(CancellationToken cancellationToken = default) where T : BaseModel;

        /// <summary>
        /// Find an entity of type T
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseModel;

        /// <summary>
        /// Update an entity of type T
        /// </summary>
        /// <param name="t"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> UpdateAsync<T>(T t, CancellationToken cancellationToken = default) where T : BaseModel;
        
        /// <summary>
        /// Delete an entity of type T
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Guid> DeleteAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseModel;
    }
}
