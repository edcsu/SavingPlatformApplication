using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Models.Enums;

namespace SavingPlatformApplication.Models
{
    public class Asset
    {
        public string Name { get; set; }

        public decimal MonetaryValue { get; set; }

        public AssetCategories AssetCategory { get; set; }

        public Guid OwnerId { get; set; }
        public Client IndividualOwner { get; set; }
        public SavingsGroup SavingsGroupOwner { get; set; }

        public bool IsIndividualyOwned { get; set; }

        public string VendorId { get; set; }
        public Guid IndividualVendor { get; set; }
        public SavingsGroup SavingsGroupVendor { get; set; }
        public bool IsIndividualySold { get; set; }
    }
}
