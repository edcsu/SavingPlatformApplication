using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.Data.Models
{
#nullable disable
    public class Address : BaseModel
    {
        public string Country { get; set; }

        public string Town { get; set; }

#nullable enable
        public string? StreetName { get; set; }

    }
}
