using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.Data.Models
{
    public class Transaction : BaseModel
    {
        public double Price { get; set; }

        public TransactionType Type { get; set; }

        public Guid ClientId { get; set; }
        public bool IsMadeByMember { get; set; }

#nullable disable
        public Member Member { get; set; }
        public SavingsGroup SavingsGroup { get; set; }
    }
}
