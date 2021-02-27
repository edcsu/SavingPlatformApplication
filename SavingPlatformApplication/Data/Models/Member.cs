using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SavingPlatformApplication.Data.Models
{

#nullable disable
    public class Member : BaseModel
    {
        public Address Address { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal Balance { get; set; }

        public ICollection<SavingsGroup> SavingsGroups { get; set; }
        
        public ICollection<Credit> Credits { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
