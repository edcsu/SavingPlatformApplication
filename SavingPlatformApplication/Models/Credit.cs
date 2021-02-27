using System;

namespace SavingPlatformApplication.Models
{
    public class Credit : BaseModel
    {
        public decimal FinancialResourceAmount { get; set; }

        public decimal PercentInterest { get; set; }

        public DateTime PaymentPeriod { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}