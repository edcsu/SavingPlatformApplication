using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavingPlatformApplication.Data;
using SavingPlatformApplication.Repositories.Contracts;

namespace SavingPlatformApplication.Repositories.Implementations
{
    public class SavingsGroupRepository : BaseRepository, ISavingsGroupRepository
    {
        private readonly ApplicationDbContext _context;
        
        public SavingsGroupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Guid> DeleteAsync<Member>(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.SavingsGroups
                .Include(m => m.Address)
                    .SingleAsync(a => a.Id == id);
            _context.SavingsGroups.Remove(entity);

            await _context.SaveChangesAsync();
            return id;
        }
    }
}
