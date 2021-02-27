using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.Models
{
    public class Address : BaseModel
    {
        public string Country { get; set; }

        public string Town { get; set; }

        public string StreetName { get; set; }

    }
}
