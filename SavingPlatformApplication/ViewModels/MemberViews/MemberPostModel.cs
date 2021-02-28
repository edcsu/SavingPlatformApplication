using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.ViewModels.MemberViews
{
    public class MemberPostModel
    {
#nullable disable
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

#nullable enable
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Balance { get; set; }
    }
}
