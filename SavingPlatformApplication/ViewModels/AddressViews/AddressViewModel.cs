using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.ViewModels.AddressViews
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

#nullable disable
        public string Country { get; set; }

        public string Town { get; set; }

#nullable enable
        public string? StreetName { get; set; }
    }
}
