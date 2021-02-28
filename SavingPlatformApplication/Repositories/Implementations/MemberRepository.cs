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
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Guid> DeleteAsync<Member>(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Members.Include(m => m.Address)
                    .Include(m => m.SavingsGroups)
                    .SingleAsync(a => a.Id == id);
            _context.Members.Remove(entity);

            await _context.SaveChangesAsync();
            return id;
        }
    }
}
