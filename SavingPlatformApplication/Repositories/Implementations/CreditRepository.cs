using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data;
using SavingPlatformApplication.Repositories.Contracts;

namespace SavingPlatformApplication.Repositories.Implementations
{
    public class CreditRepository : BaseRepository, ICreditRepository
    {
        public CreditRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
