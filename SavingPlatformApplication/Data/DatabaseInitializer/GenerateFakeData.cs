using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using SavingPlatformApplication.Data.Models;

namespace SavingPlatformApplication.Data.DatabaseInitializer
{
    public class GenerateFakeData
    {
        public static List<Member> GetSampleMembers(int limit = 1)
        {
            var memberFaker = new Faker<Member>()
                .RuleFor(c => c.FullName, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(c => c.Balance, f => Convert.ToDouble(f.Finance.Amount(max: 1000000000)));

            return memberFaker.Generate(limit);
        }
        
        public static List<SavingsGroup> GetSampleSavingsGroups(int limit = 1)
        {
            var groupFaker = new Faker<SavingsGroup>()
                .RuleFor(c => c.FullName, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(c => c.Balance, f => Convert.ToDouble(f.Finance.Amount(max: 1000000000)))
                .RuleFor(u => u.Members, f => GetSampleMembers(20));
            
            return groupFaker.Generate(limit);
        }

    }
}
