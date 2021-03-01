using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels;
using SavingPlatformApplication.ViewModels.MemberViews;
using SavingPlatformApplication.ViewModels.SavingsGroupViews;

namespace SavingsPlatformApplication.Test
{
    public class TestHelpers
    {
        public static SearchRequest GetTestSearchRequest()
        {
            return new SearchRequest
            {
            };
        }

        public static List<MemberViewModel> GetSampleMembers(int limit = 1)
        {
            var memberFaker = new Faker<MemberViewModel>()
                .RuleFor(m => m.FullName, f => f.Name.FullName())
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(m => m.BirthDate, f => f.Date.Past(30).ToUniversalTime())
                .RuleFor(m => m.DateCreated, f => f.Date.Past(1).ToUniversalTime())
                .RuleFor(m => m.Balance, f => Convert.ToDouble(f.Finance.Amount(min: 10000, max: 1000000000)));

            return memberFaker.Generate(limit);
        }

        public static MemberSearchResponse GetTestMemberSearchResponseResults()
        {
            var membersList = GetSampleMembers(10);

            return new MemberSearchResponse
            {
                MembersList = membersList,
                Pagination = new SearchPagination
                {
                    TotalItems = membersList.Count
                }
            };
        }

        public static List<SavingsGroupViewModel> GetSampleSavingsGroups(int limit = 1)
        {
            var savingsGroupFaker = new Faker<SavingsGroupViewModel>()
                .RuleFor(g => g.FullName, f => f.Name.FullName())
                .RuleFor(g => g.Email, f => f.Person.Email)
                .RuleFor(g => g.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(g => g.Balance, f => Convert.ToDouble(f.Finance.Amount(min: 200000, max: 1000000000)))
                .RuleFor(g => g.DateFounded, f => f.Date.Past(10).ToUniversalTime())
                .RuleFor(g => g.DateCreated, f => f.Date.Past(1).ToUniversalTime());

            return savingsGroupFaker.Generate(limit);
        }

        public static SavingsGroupSearchResponse GetTestSavingsGroupSearchResponseResults()
        {
            var savingsGroupList = GetSampleSavingsGroups(10);

            return new SavingsGroupSearchResponse
            {
                SavingsGroupList = savingsGroupList,
                Pagination = new SearchPagination
                {
                    TotalItems = savingsGroupList.Count
                }
            };
        }
    }
}
