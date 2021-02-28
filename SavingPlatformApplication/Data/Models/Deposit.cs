using System;

namespace SavingPlatformApplication.Data.Models
{
    public class Deposit : BaseModel
    {
        public double Amount { get; set; }

        public Guid SavingsGroupId { get; set; }
#nullable disable
        public SavingsGroup SavingsGroup { get; set; }
    }
}