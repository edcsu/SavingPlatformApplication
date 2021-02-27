using System;

namespace SavingPlatformApplication.Data.Models
{
    public class Credit : BaseModel
    {
        public double FinancialResourceAmount { get; set; }

        public double PercentInterest { get; set; }

        public DateTime PaymentPeriod { get; set; }


#nullable disable
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

    }
}