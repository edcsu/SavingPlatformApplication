using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Models.Enums;

namespace SavingPlatformApplication.Models
{
    public class Transaction
    {
        public decimal Price { get; set; }

        public TransactionType Type { get; set; }

        public Guid ClientId { get; set; }
        public bool IsMadeByMember { get; set; }

#nullable disable
        public Member Member { get; set; }
        public SavingsGroup SavingsGroup { get; set; }
    }
}
