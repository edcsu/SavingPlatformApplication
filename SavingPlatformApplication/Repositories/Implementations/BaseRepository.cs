using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SavingPlatformApplication.Repositories.Contracts;

namespace SavingPlatformApplication.Repositories.Implementations
{
    public class BaseRepository : IBaseRepository
    {
        public Task<T> AddAsync<T>(T t, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync<T>(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync<T>(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(T t, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
