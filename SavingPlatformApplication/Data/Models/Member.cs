using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.Data.Models
{

#nullable disable
    public class Member : BaseModel
    {
        public Address Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; } 

        public DateTime BirthDate { get; set; }

        public double Balance { get; set; }

        public ICollection<SavingsGroup> SavingsGroups { get; set; }
    }
}
