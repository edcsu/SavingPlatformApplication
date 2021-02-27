using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavingPlatformApplication.Data.Models;

namespace SavingPlatformApplication.Data
{

#nullable disable
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Credit> Credits { get; set; }
        
        public DbSet<Deposit> Deposits { get; set; }
        
        public DbSet<Member> Members { get; set; }
        
        public DbSet<SavingsGroup> SavingsGroups { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
