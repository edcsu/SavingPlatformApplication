using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.ViewModels.AddressViews
{
    public class AddressPostModel
    {
#nullable disable
        [Required]
        public string Country { get; set; }

        [Required]
        public string Town { get; set; }

#nullable enable
        public string? StreetName { get; set; }
    }
}
