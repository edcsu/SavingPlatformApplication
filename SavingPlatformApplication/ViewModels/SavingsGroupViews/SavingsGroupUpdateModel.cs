using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models;
using SavingPlatformApplication.ViewModels.AddressViews;

namespace SavingPlatformApplication.ViewModels.SavingsGroupViews
{
    public class SavingsGroupUpdateModel
    {
#nullable disable
        [Required]
        public AddressPostModel Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string FullName { get; set; }

#nullable enable
        [Required]
        public DateTime DateFounded { get; set; }

        [Required]
        public double Balance { get; set; }

    }
}
