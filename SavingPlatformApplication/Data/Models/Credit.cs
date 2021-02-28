using System;

namespace SavingPlatformApplication.Data.Models
{
    public class Credit : BaseModel
    {
        public double FinancialResourceAmount { get; set; }

        public double PercentInterest { get; set; }

        public DateTime PaymentPeriod { get; set; }

        public Guid SavingsGroupId { get; set; }
#nullable disable
        public SavingsGroup SavingsGroup { get; set; }

    }
}