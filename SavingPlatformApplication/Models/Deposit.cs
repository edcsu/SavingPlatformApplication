using System;

namespace SavingPlatformApplication.Models
{
    public class Deposit : BaseModel
    {
        public decimal Amount { get; set; }

        public Guid ClientId { get; set; }
        public bool IsMadeByMember { get; set; }
        public Member Member { get; set; }
        public SavingsGroup SavingsGroup { get; set; }
    }
}