using System;

namespace SavingPlatformApplication.Models
{
    public class Deposit : BaseModel
    {
        public decimal Amount { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}