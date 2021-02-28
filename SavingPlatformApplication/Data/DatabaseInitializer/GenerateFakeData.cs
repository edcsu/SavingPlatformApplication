using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.Data.DatabaseInitializer
{
    public class GenerateFakeData
    {
        public static Address GetSampleAddress()
        {
            return new Faker<Address>()
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.Town, f => f.Address.City())
                .RuleFor(a => a.StreetName, f => f.Address.StreetName())
                .RuleFor(a => a.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .Generate();
        }
        
        public static List<Member> GetSampleMembers(int limit = 1)
        {
            var memberFaker = new Faker<Member>()
                .RuleFor(m => m.FullName, f => f.Name.FullName())
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(m => m.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.Address, f => GetSampleAddress())
                .RuleFor(m => m.Balance, f => Convert.ToDouble(f.Finance.Amount(min: 10000, max: 1000000000)));

            return memberFaker.Generate(limit);
        }
        
        public static List<Asset> GetSampleAssets(int limit = 1)
        {
            var assetFaker = new Faker<Asset>()
                .RuleFor(m => m.Name, f => f.Commerce.ProductName())
                .RuleFor(m => m.AssetCategory, f => f.PickRandom<AssetCategories>())
                .RuleFor(m => m.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.MonetaryValue, f => Convert.ToDouble(f.Finance.Amount(min: 100000, max: 1000000000)));

            return assetFaker.Generate(limit);
        }

        public static List<Credit> GetSampleCredits(int limit = 1)
        {
            var creditFaker = new Faker<Credit>()
                .RuleFor(m => m.PercentInterest, f => Math.Round(f.Random.Double(min: 0.1)*100, 2))
                .RuleFor(m => m.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.PaymentPeriod, f => f.Date.Future(1).ToUniversalTime())
                .RuleFor(m => m.FinancialResourceAmount, f => Convert.ToDouble(f.Finance.Amount(min: 50000, max: 1000000000)));

            return creditFaker.Generate(limit);
        }
        
        public static List<Deposit> GetSampleDeposits(int limit = 1)
        {
            var depositFaker = new Faker<Deposit>()
                .RuleFor(m => m.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.Amount, f => Convert.ToDouble(f.Finance.Amount(min: 5000, max: 1000000000)));

            return depositFaker.Generate(limit);
        }
        
        public static List<Transaction> GetSampleTransactions(int limit = 1)
        {
            var transactionFaker = new Faker<Transaction>()
                .RuleFor(m => m.Type, f => f.PickRandom<TransactionType>())
                .RuleFor(m => m.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.Price, f => Convert.ToDouble(f.Finance.Amount(min: 5000, max: 1000000000)));

            return transactionFaker.Generate(limit);
        }
        
        public static List<SavingsGroup> GetSampleSavingsGroups(int limit = 1)
        {
            var groupFaker = new Faker<SavingsGroup>()
                .RuleFor(g => g.FullName, f => f.Name.FullName())
                .RuleFor(g => g.Email, f => f.Person.Email)
                .RuleFor(g => g.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(g => g.Balance, f => Convert.ToDouble(f.Finance.Amount(min: 200000, max: 1000000000)))
                .RuleFor(g => g.DateFounded, f => f.Date.Past(10).ToUniversalTime())
                .RuleFor(g => g.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.Address, f => GetSampleAddress())
                .RuleFor(g => g.Members, f => GetSampleMembers(25))
                .RuleFor(g => g.Credits, f => GetSampleCredits(10))
                .RuleFor(g => g.Deposits, f => GetSampleDeposits(10))
                .RuleFor(g => g.Transactions, f => GetSampleTransactions(10));
            
            return groupFaker.Generate(limit);
        }

    }
}
