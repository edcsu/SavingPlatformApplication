using System.Collections.Generic;

namespace SavingPlatformApplication.Data.Models
{

#nullable disable
    public class SavingsGroup : Client
    {
        public ICollection<Member> Members { get; set; }
    }
}