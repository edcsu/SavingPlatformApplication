using System.Collections.Generic;

namespace SavingPlatformApplication.Models
{
    public class SavingsGroup : BaseModel
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Credit> Credits { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}