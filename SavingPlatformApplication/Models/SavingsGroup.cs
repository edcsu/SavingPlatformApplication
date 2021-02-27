using System.Collections.Generic;

namespace SavingPlatformApplication.Models
{
    public class SavingsGroup : BaseModel
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}