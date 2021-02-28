using System;
using System.Collections.Generic;

namespace SavingPlatformApplication.Data.Models
{

#nullable disable
    public class SavingsGroup : BaseModel
    {
        public Address Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public double Balance { get; set; }

        public ICollection<Asset> CreatedAssets { get; set; }

        public ICollection<Asset> PurchasedAssets { get; set; }

        public ICollection<Credit> Credits { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}