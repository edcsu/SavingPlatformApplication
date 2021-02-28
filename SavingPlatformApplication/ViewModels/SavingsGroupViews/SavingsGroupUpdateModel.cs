using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels.AddressViews;

namespace SavingPlatformApplication.ViewModels.SavingsGroupViews
{
    public class SavingsGroupUpdateModel
    {
#nullable disable
        public AddressPostModel Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

#nullable enable
        public DateTime DateFounded { get; set; }

        public double Balance { get; set; }

    }
}
