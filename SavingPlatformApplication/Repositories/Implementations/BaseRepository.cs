using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavingPlatformApplication.Data;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Repositories.Contracts;

namespace SavingPlatformApplication.Repositories.Implementations
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public async Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : BaseModel
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
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
