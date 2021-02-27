using System;

namespace SavingPlatformApplication.Data.Models
{
    public class Deposit : BaseModel
    {
        public double Amount { get; set; }

        public Guid ClientId { get; set; }
#nullable disable
        public Client Client { get; set; }
    }
}