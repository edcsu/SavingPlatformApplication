using System;

namespace SavingPlatformApplication.Models
{
    public class Credit : BaseModel
    {
        public decimal FinancialResourceAmount { get; set; }

        public decimal PercentInterest { get; set; }

        public DateTime PaymentPeriod { get; set; }

        public bool IsMadeByMember { get; set; }
        public Member Member { get; set; }
        public SavingsGroup SavingsGroup { get; set; }
    }
}