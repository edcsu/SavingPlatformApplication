using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.Data.Models
{
    public class Asset
    {
#nullable disable
        public string Name { get; set; }

        public double MonetaryValue { get; set; }

        public AssetCategories AssetCategory { get; set; }

        public Guid SavingsGroupId { get; set; }
        public SavingsGroup SavingsGroup { get; set; }
    }
}
