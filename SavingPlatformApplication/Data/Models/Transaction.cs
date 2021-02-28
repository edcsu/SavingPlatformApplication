using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SavingPlatformApplication.Data.Models.Enums;

namespace SavingPlatformApplication.Data.Models
{
    public class Transaction : BaseModel
    {
        public double Price { get; set; }

        public TransactionType Type { get; set; }

        public Guid SavingsGroupId { get; set; }
#nullable disable
        public SavingsGroup SavingsGroup { get; set; }
    }
}
