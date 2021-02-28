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

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Credit> Credits { get; set; }
        
        public DbSet<Deposit> Deposits { get; set; }
        
        public DbSet<Member> Members { get; set; }
        
        public DbSet<SavingsGroup> SavingsGroups { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Asset>()
                .HasOne(a => a.SavingsGroup)
                .WithMany(c => c.CreatedAssets)
                .HasForeignKey(a => a.SavingsGroupId);

            builder.Entity<Credit>()
                .HasOne(cr => cr.SavingsGroup)
                .WithMany(cl => cl.Credits)
                .HasForeignKey(cr => cr.SavingsGroupId);

            builder.Entity<Deposit>()
                .HasOne(d => d.SavingsGroup)
                .WithMany(c => c.Deposits)
                .HasForeignKey(d => d.SavingsGroupId);

            builder.Entity<Transaction>()
                .HasOne(t => t.SavingsGroup)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.SavingsGroupId);

            base.OnModelCreating(builder);
        }
    }
}
