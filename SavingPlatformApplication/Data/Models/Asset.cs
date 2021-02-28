using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.Data.Models
{
    public class Asset : BaseModel
    {
#nullable disable
        public string Name { get; set; }

        public double MonetaryValue { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public AssetCategories AssetCategory { get; set; }

        public Guid SavingsGroupId { get; set; }
        public SavingsGroup SavingsGroup { get; set; }
    }
}
