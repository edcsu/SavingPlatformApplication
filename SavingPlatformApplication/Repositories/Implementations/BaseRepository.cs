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

        public async Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : BaseModel
        {
            await _context.Set<T>().AddAsync(entity);
            
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<T> DeleteAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseModel
        {
            var customer = await _context.Set<T>().SingleAsync(a => a.Id == id);
            _context.Set<T>().Remove(customer);

            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> ExistsAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseModel
        {
            return await _context.Set<T>().AnyAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseModel
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : BaseModel
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync<T>(CancellationToken cancellationToken = default) where T : BaseModel
        {
            return await _context.Set<T>().CountAsync(cancellationToken);
        }

        public async Task<T> UpdateAsync<T>(T entity, CancellationToken cancellationToken = default) where T : BaseModel
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
