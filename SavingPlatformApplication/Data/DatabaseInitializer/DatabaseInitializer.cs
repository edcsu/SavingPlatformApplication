using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SavingPlatformApplication.Data.DatabaseInitializer
{
    public class DatabaseInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (!await context.Members.AnyAsync())
            {
                SeedMembers(context);
                await context.SaveChangesAsync();
            }
            
            if (!await context.SavingsGroups.AnyAsync())
            {
                SeedSavingsGroups(context);
                await context.SaveChangesAsync();
            }
        }

        private static void SeedMembers(ApplicationDbContext context)
        {
            context.Members.AddRange(GenerateFakeData.GetSampleMembers(150));
            context.SaveChanges();
        }

        private static void SeedSavingsGroups(ApplicationDbContext context)
        {
            context.SavingsGroups.AddRange(GenerateFakeData.GetSampleSavingsGroups(150));
            context.SaveChanges();
        }
    }
}
