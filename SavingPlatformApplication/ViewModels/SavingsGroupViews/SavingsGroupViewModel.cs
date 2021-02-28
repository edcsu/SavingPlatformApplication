using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels.AddressViews;

namespace SavingPlatformApplication.ViewModels.SavingsGroupViews
{
    public class SavingsGroupViewModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

#nullable disable
        public AddressPostModel Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

#nullable enable
        public DateTime DateFounded { get; set; }

        public double Balance { get; set; }

#nullable disable
        public ICollection<Asset> CreatedAssets { get; set; }

        public ICollection<Asset> PurchasedAssets { get; set; }

        public ICollection<Credit> Credits { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
